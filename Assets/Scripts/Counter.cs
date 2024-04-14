using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Counter : MonoBehaviour
{
    [SerializeField] private PlayerInput _input;
    [SerializeField] private float _period = 1.0f;

    private int _counterValue = 0;
    private bool _isCountOn = true;
    private Coroutine _count;
    private float _elapsedTime = 0;

    public event UnityAction ValueChanged;

    public int CounterValue => _counterValue;

    private void Start()
    {
        _count = StartCoroutine(Count());
    }

    private void OnEnable()
    {
        _input.PressedButton += ToggleCounter;
    }

    private void OnDisable()
    {
        _input.PressedButton -= ToggleCounter;

        StopCoroutine(_count);
    }

    private void Update()
    {
        if (_elapsedTime >= _period)
        {
            _counterValue += 1;
            ValueChanged?.Invoke();
            _elapsedTime = 0;
        }
    }

    public void ToggleCounter()
    {
        _isCountOn = !_isCountOn;
    }

    private IEnumerator Count()
    {
        while (true)
        {
            if (_isCountOn)
                _elapsedTime += Time.deltaTime;

            yield return null;
        }
    }
}