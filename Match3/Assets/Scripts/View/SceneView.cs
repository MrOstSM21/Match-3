using UnityEngine;

public class SceneView : MonoBehaviour
{
    [SerializeField] private GameObject _endGameBaner;

    private void Start()
    {
        _endGameBaner.SetActive(false);
        Subscribe();
    }

    private void TimeHandler_EndGame()
    {
        _endGameBaner.SetActive(true);
        Unsubscribe();
    }
    private void Subscribe() => TimeHandler.EndGame += TimeHandler_EndGame;

    private void Unsubscribe() => TimeHandler.EndGame -= TimeHandler_EndGame;
}
