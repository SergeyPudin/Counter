using TMPro;
using UnityEngine;

public class CountRenderer : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private TMP_Text _textMeshPro;

    private void OnEnable()
    {
        _counter.ValueChanged += ChangeNumber;
    }

    private void OnDisable()
    {
        _counter.ValueChanged -= ChangeNumber;
    }

    private void ChangeNumber()
    {
        int value = _counter.CounterValue;

        _textMeshPro.text = value.ToString();
    }
}