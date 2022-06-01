using UnityEngine;

public class Tile
{
    public bool _isMatch = false;
    private TileView _tileView;
    private bool _isMark = false;

    public TilesName TilesName { get { return _tileView.TilesName; } }
    public TileView View { get { return _tileView; } }
    public bool GetIsMark ()
    {
        return _isMark;
    }

    public Tile(TileView tileView)
    {
        _tileView = tileView;
        _tileView.IsPushed += _tileView_IsPushed;
    }
    public void SetPosition(Vector2 position)
    {
        _tileView.SetPosition(position);
        _isMark = false;
    }

    private void _tileView_IsPushed()
    {
        
        if (_isMark)
        {
            _isMark = false;
        }
        else
        {
            _isMark = true;
        }
        Debug.Log("tile" + _tileView.transform.position +"Tile" + _isMark);
    }
}
