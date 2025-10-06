using UnityEngine;

public class CraneController : MonoBehaviour
{
    [Header("—корости")]
    [SerializeField] private float speedUpDown = 1f;
    [SerializeField] private float speedLeftRight = 1f;
    [SerializeField] private float speedForwardBackward = 1f;
    [Header("Ёлементы крана")]
    [SerializeField] private GameObject Bridge;//балка
    [SerializeField] private GameObject Trolley;//тележка
    [SerializeField] private GameObject Hook;//крюк
    [Header("ќграничени€ движени€")]
    [SerializeField] private Vector2 hookYLimits = new Vector2(-3f, 2f);
    [SerializeField] private Vector2 trolleyXLimits = new Vector2(-50f, 50f);
    [SerializeField] private Vector2 bridgeZLimits = new Vector2(-9f, 9f);

    private Vector3 hookDirection = Vector3.zero;
    private Vector3 trolleyDirection = Vector3.zero;
    private Vector3 bridgeDirection = Vector3.zero;

    private void Update()
    {
        if (hookDirection != Vector3.zero)
        {
            Hook.transform.Translate(hookDirection * speedUpDown * Time.deltaTime, Space.Self);

            Vector3 pos = Hook.transform.localPosition;
            pos.y = Mathf.Clamp(pos.y, hookYLimits.x, hookYLimits.y);
            Hook.transform.localPosition = pos;
        }

        if (trolleyDirection != Vector3.zero)
        {
            Trolley.transform.Translate(trolleyDirection * speedLeftRight * Time.deltaTime, Space.Self);

            Vector3 pos = Trolley.transform.localPosition;
            pos.x = Mathf.Clamp(pos.x, trolleyXLimits.x, trolleyXLimits.y);
            Trolley.transform.localPosition = pos;
        }

        if (bridgeDirection != Vector3.zero)
        {
            Bridge.transform.Translate(bridgeDirection * speedForwardBackward * Time.deltaTime, Space.Self);

            Vector3 pos = Bridge.transform.localPosition;
            pos.z = Mathf.Clamp(pos.z, bridgeZLimits.x, bridgeZLimits.y);
            Bridge.transform.localPosition = pos;
        }
    }

    public void MoveUp() => hookDirection = Vector3.up;
    public void MoveDown() => hookDirection = Vector3.down;
    public void MoveLeft() => trolleyDirection = Vector3.left;
    public void MoveRight() => trolleyDirection = Vector3.right;
    public void MoveForward() => bridgeDirection = Vector3.forward;
    public void MoveBackward() => bridgeDirection = Vector3.back;

    public void Stop()
    {
        hookDirection = Vector3.zero;
        trolleyDirection = Vector3.zero;
        bridgeDirection = Vector3.zero;
    }
}