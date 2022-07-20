
public class ScoreData
{
    public int GetScore { get { return _score; } }
    public int GetBestScore { get { return _bestScore; } }

    private int _score;
    private int _bestScore;

    public ScoreData()
    {
        _score = 0;
        _bestScore = 0;
    }

    public void AddScore(int points)=> _score += points;
    
    public void SetBestScore(int points) => _bestScore = points;
   
}
