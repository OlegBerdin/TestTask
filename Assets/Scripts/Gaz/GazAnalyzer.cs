using UnityEngine;
using System;

public class GazAnalyzer : MonoBehaviour
{
    public event Action GazPressed;
    public event Action GazReleased;

    [Header(" нопки пульта")]
    [SerializeField] private RemoteButton gazButton;

    private void Awake()
    {
        gazButton.OnPressed.AddListener(() => GazPressed?.Invoke());

        gazButton.OnReleased.AddListener(() => GazReleased?.Invoke());
    }
}