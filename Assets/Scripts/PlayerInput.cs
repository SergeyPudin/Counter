using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Counter _counter;

    public event UnityAction PressedButton;

    private void Update()
    {
        if (_counter != null && Input.GetMouseButtonDown(0))
            PressedButton?.Invoke();
    }
}