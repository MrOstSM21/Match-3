using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreData
{
    public int GetScore { get { return _score; } }

    private int _score;

    public ScoreData()
    {
        _score = 0;
    }

    public void AddScore(int points)
    {
        _score += points;
    }
}
