using UnityEngine;

public class GameManagerCrane : MonoBehaviour
{
    [SerializeField] private RemoteControl remote;
    [SerializeField] private CraneController crane;

    private void OnEnable()
    {
        remote.MoveUp += crane.MoveUp;
        remote.MoveDown += crane.MoveDown;
        remote.MoveLeft += crane.MoveLeft;
        remote.MoveRight += crane.MoveRight;
        remote.MoveForward += crane.MoveForward;
        remote.MoveBackward += crane.MoveBackward;
        remote.Stop += crane.Stop;
    }

    private void OnDisable()
    {
        remote.MoveUp -= crane.MoveUp;
        remote.MoveDown -= crane.MoveDown;
        remote.MoveLeft -= crane.MoveLeft;
        remote.MoveRight -= crane.MoveRight;
        remote.MoveForward -= crane.MoveForward;
        remote.MoveBackward -= crane.MoveBackward;
        remote.Stop -= crane.Stop;
    }
}
