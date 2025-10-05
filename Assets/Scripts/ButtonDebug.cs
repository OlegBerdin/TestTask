using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonDebug : MonoBehaviour
{
    public UnityEvent OnPressed;
    public UnityEvent OnReleased;
    public void ButtonOnPressed()
    {
        OnPressed?.Invoke();
        Debug.Log("press");
    }
    public void ButtonReleased()
    {
        OnReleased?.Invoke();
        Debug.Log("relese");
    }
}
