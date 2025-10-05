using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Button))]
public class RemoteButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [HideInInspector]public UnityEvent OnPressed;
    [HideInInspector]public UnityEvent OnReleased;

    public void OnPointerDown(PointerEventData eventData)
    {
        OnPressed?.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnReleased?.Invoke();
    }
}
