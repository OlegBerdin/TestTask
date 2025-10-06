using UnityEngine;

public class GameManagerGaz : MonoBehaviour
{
    [SerializeField] private GazAnalyzer gazAnalyzer;
    [SerializeField] private GazController gazController;

    private void OnEnable()
    {
        gazAnalyzer.GazPressed += gazController.GazPressed;
        gazAnalyzer.GazReleased += gazController.GazReleased;
    }

    private void OnDisable()
    {
        gazAnalyzer.GazPressed -= gazController.GazPressed;
        gazAnalyzer.GazReleased -= gazController.GazReleased;
    }
}
