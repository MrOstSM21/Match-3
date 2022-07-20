
public class ScoreHandler
{
    private readonly ScoreData _scoreData;
    private readonly ScoreView _scoreView;

    public ScoreHandler(ScoreView scoreView)
    {
        _scoreData = new ScoreData();
        _scoreView = scoreView;
        SetStartBestScore();
        Subscribe();
    }

    public void ChangeScore(int points)
    {
        _scoreData.AddScore(points);
        _scoreView.SetScore(_scoreData.GetScore);
    }
    private void TimeHandler_EndGame()
    {
        if (_scoreData.GetScore > _scoreData.GetBestScore)
        {
            var saver = new SaveHandler();
            saver.Save(_scoreData.GetScore);
        }
        Unsubscribe();
    }
    private void SetStartBestScore()
    {
        var saver = new SaveHandler();
        _scoreData.SetBestScore(saver.Load()._score);
        _scoreView.SetBestScore(_scoreData.GetBestScore);
    }
    private void Subscribe() => TimeHandler.EndGame += TimeHandler_EndGame;
    private void Unsubscribe() => TimeHandler.EndGame -= TimeHandler_EndGame;

}
