using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile
{
    private TileView _tileView;

    public TilesName TilesName { get { return _tileView.TilesName; } }
    public TileView View { get { return _tileView; } }

    public Tile(TileView tileView)
    {
        _tileView = tileView;
    }
}
