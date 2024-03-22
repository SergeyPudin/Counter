using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Counter : MonoBehaviour
{
    [SerializeField] private PlayerInput _input;

    private int _counterValue = 0;
    private int _pauseTime = 1;
    private bool _isCountOn = true;
    private Coroutine _count;

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
    }

    public void ToggleCounter()
    {
        if (_isCountOn)
        {
            StopCoroutine(_count);

            _isCountOn = false;
        }
        else
        {
            _count = StartCoroutine(Count());

            _isCountOn = true;
        }
    }

    private IEnumerator Count()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_pauseTime);

        while (true)
        {
            _counterValue++;
            ValueChanged?.Invoke();

            yield return waitForSeconds;
        }
    }
}