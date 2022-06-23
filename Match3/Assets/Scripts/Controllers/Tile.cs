using UnityEngine;

public class Tile
{
    private bool _isMatch = false;
    private bool _isMark = false;

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

    public void SetTileViewSwap(Vector2 position)
    {
        _tileView.SetPosition(position, true,_gameData.SwapTileSpeed);
        _isMark = false;
    }public void SetTileViewMove(Vector2 position)
    {
        _tileView.SetPosition(position, true,_gameData.MoveTileSpeed);
        _isMark = false;
    }
    public void ChangeIsMatch()
    {
        _isMatch = true;
    }
    public bool GetIsMatch()
    {
        return _isMatch;
    }
    public void tileView_IsPushed()
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
    public bool GetIsMark()
    {
        return _isMark;
    }
    public  bool GetTileViewIsMove()
    {
        return _tileView.GetIsMove();
    }
    private void tileView_IsDestroy()
    {
        _scoreview.SetScore(_gameData.GetPoints[TilesName]);
        _tileView.IsPushed -= tileView_IsPushed;
        _tileView.IsDestroy -= tileView_IsDestroy;

    }
}
