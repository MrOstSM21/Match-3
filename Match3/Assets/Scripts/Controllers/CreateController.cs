using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateController
{

    private GameData _gameData;
    private Vector2[,] _gridSpawnPoints;
    private GridCreater _gridCreater;
    private TileFactory _tileFactory;
    private TileView[,] _tilesViews = new TileView[GameData.GRID_X, GameData.GRID_Y];
    private int _spriteCount;


    public CreateController(GameData gameData, TileSpritesView tileSpritesView, TileView tileView)
    {
        _gameData = gameData;
        _gridCreater = new GridCreater(_gameData);
        var sprites = tileSpritesView.GetSprites();
        _spriteCount = sprites.Count;
        _tileFactory = new TileFactory(sprites, tileView);
    }

    public void Init()
    {
        CreateGrid();
        for (int y = 0; y < GameData.GRID_X; y++)
        {
            for (int x = 0; x < GameData.GRID_Y; x++)
            {
                CreateTile(x, y);
            }
        }

    }

    public TileView[,] GetTilesView()
    {
        return _tilesViews;
    }

    public bool ReplaseTile(List<Vector2Int> matchTiles)
    {
        bool isMatch=false;
        foreach (var tileIndex in matchTiles)
        {
            if (_tilesViews[tileIndex.y, tileIndex.x] != null)
            {
                isMatch = true;
                _tilesViews[tileIndex.y, tileIndex.x].DestroyTile();
                CreateTile(tileIndex.x, tileIndex.y);
            }
        }
        return isMatch;
    }
    private void CreateTile(int x, int y)
    {
        var tileName = Random.Range(0, _spriteCount);
        var tile = _tileFactory.CreateTile(_gridSpawnPoints[y, x], (TilesName)tileName);
        if (tile != null)
        {
            _tilesViews[y, x] = tile.View;
        }
    }
    private void CreateGrid()
    {
        _gridSpawnPoints = _gridCreater.CreateGridSpawnPoint();
    }
}
