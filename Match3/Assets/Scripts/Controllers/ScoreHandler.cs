
public class ScoreHandler
{
    private readonly ScoreData _scoreData;
    private readonly ScoreView _scoreView;

    public ScoreHandler(ScoreView scoreView)
    {
        _scoreData = new ScoreData();
        _scoreView = scoreView;
    }
    public void ChangeScore(int points)
    {
        _scoreData.AddScore(points);
        _scoreView.SetScore(_scoreData.GetScore);

    }
}
