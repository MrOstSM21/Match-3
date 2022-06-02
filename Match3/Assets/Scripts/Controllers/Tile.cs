using UnityEngine;

public class Tile
{
    public bool _isMatch = false;
    public bool _isMark = false;

    public TilesName TilesName { get { return _tileView.TilesName; } }
    public TileView View { get { return _tileView; } }

    private readonly TileView _tileView;
    private readonly ScoreView _scoreview;
    private readonly GameData _gameData;

    public Tile(TileView tileView, ScoreView scoreView, GameData gameData)
    {
        _tileView = tileView;
        _scoreview = scoreView;
        _gameData = gameData;
        _tileView.IsPushed += tileView_IsPushed;
        _tileView.IsDestroy += tileView_IsDestroy;

    }

    public void SetPosition(Vector2 position)
    {
        _tileView.SetPosition(position, true);
        _isMark = false;
    }

    private void tileView_IsPushed()
    {

        if (_isMark)
        {
            _isMark = false;
        }
        else
        {
            _isMark = true;
        }
    }
    private void tileView_IsDestroy()
    {
        _scoreview.SetScore(_gameData.GetPoints[TilesName]);
        _tileView.IsPushed -= tileView_IsPushed;
        _tileView.IsDestroy -= tileView_IsDestroy;

    }
}
