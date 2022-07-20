using UnityEngine;

public class Tile
{
    public TilesName TilesName { get { return _tileView.TilesName; } }
    public TileView View { get { return _tileView; } }
    public bool GetIsMatch { get { return _isMatch; } }
    public bool GetIsMark { get { return _isMark; } }
    public bool GetTileViewIsMove { get { return _tileView.GetIsMove; } }

    private readonly TileView _tileView;
    private readonly ScoreHandler _scoreHandler;
    private readonly GameData _gameData;

    private bool _isMatch = false;
    private bool _isMark = false;

    public Tile(TileView tileView, ScoreHandler scoreHandler, GameData gameData)
    {
        _tileView = tileView;
        _scoreHandler = scoreHandler;
        _gameData = gameData;
        _tileView.IsPushed += tileView_IsPushed;
        _tileView.IsDestroy += tileView_IsDestroy;
    }
    public void SetMoveTileView(Vector2 position, float speed)
    {
        _tileView.SetPosition(position, true, speed);
        _isMark = false;
    }

    public void ChangeIsMatch() => _isMatch = true;

    public void tileView_IsPushed()
    {
        if (_isMark)
            _isMark = false;
        else
            _isMark = true;
    }

    private void tileView_IsDestroy()
    {
        _scoreHandler.ChangeScore(_gameData.GetPoints[TilesName]);
        _tileView.IsPushed -= tileView_IsPushed;
        _tileView.IsDestroy -= tileView_IsDestroy;
    }
}
