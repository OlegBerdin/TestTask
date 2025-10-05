using UnityEngine;

public class ControllerReturn : MonoBehaviour
{
    [SerializeField] private Transform controllerPoint;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogWarning("нет rb");
        }
    }

    public void ReturnController()
    {
        if (rb == null || controllerPoint == null) return;

        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        transform.position = controllerPoint.position;
        transform.rotation = controllerPoint.rotation;
    }
}
