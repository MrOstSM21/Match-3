using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    [SerializeField] Text _score;
    private int _points = 0;
    private void Start()
    {
        _score.text = $"Score: {_points}";
    }
    public void SetScore(int points)
    {
        _points += points;
        _score.text= $"Score: {_points}";
    }
}
