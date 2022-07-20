using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    [SerializeField] Text _score;
    [SerializeField] Text _endScore;
    [SerializeField] Text _bestScore;

    private int _points = 0;

    private void Start()
    {
        _score.text = $"Score: {_points}";
    }
    public void SetScore(int points)
    {
        _score.text = $"Score: {points}";
        _endScore.text = $"Your score: {points}";
    }
    public void SetBestScore(int points)
    {
        _bestScore.text = $"Best score: {points}";
    }
}
