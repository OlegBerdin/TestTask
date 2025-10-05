using UnityEngine;
using System;

public class RemoteControl : MonoBehaviour
{
    public event Action MoveUp;
    public event Action MoveDown;
    public event Action MoveLeft;
    public event Action MoveRight;
    public event Action MoveForward;
    public event Action MoveBackward;
    public event Action Stop;

    [Header(" нопки пульта")]
    [SerializeField] private RemoteButton upButton;
    [SerializeField] private RemoteButton downButton;
    [SerializeField] private RemoteButton leftButton;
    [SerializeField] private RemoteButton rightButton;
    [SerializeField] private RemoteButton forwardButton;
    [SerializeField] private RemoteButton backwardButton;

    private void Awake()
    {
        upButton.OnPressed.AddListener(() => MoveUp?.Invoke());
        downButton.OnPressed.AddListener(() => MoveDown?.Invoke());
        leftButton.OnPressed.AddListener(() => MoveLeft?.Invoke());
        rightButton.OnPressed.AddListener(() => MoveRight?.Invoke());
        forwardButton.OnPressed.AddListener(() => MoveForward?.Invoke());
        backwardButton.OnPressed.AddListener(() => MoveBackward?.Invoke());

        upButton.OnReleased.AddListener(() => Stop?.Invoke());
        downButton.OnReleased.AddListener(() => Stop?.Invoke());
        leftButton.OnReleased.AddListener(() => Stop?.Invoke());
        rightButton.OnReleased.AddListener(() => Stop?.Invoke());
        forwardButton.OnReleased.AddListener(() => Stop?.Invoke());
        backwardButton.OnReleased.AddListener(() => Stop?.Invoke());
    }
}