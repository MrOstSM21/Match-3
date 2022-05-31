using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateController
{

    private GameData _gameData;
    private Vector2[,] _gridSpawnPoints;
    private GridCreater _gridCreater;
    private TileFactory _tileFactory;
    private Tile[,] _tiles = new Tile[GameData.GRID_X, GameData.GRID_Y];
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
    public Vector2[,] GetGridSpawnpoint()
    {
        return _gridSpawnPoints;
    }

    public Tile[,] GetTiles()
    {
        return _tiles;
    }

    public bool ReplaseTileOnStart(List<Vector2Int> matchTiles)
    {
        bool isMatch = false;
        foreach (var tileIndex in matchTiles)
        {
            if (_tiles[tileIndex.y, tileIndex.x] != null)
            {
                isMatch = true;
                _tiles[tileIndex.y, tileIndex.x].View.DestroyTile();
                CreateTile(tileIndex.x, tileIndex.y);
            }
        }
        return isMatch;
    }
    public void DectroyMatchTiles(List<Vector2Int> matchTiles)
    {
        foreach (var tileIndex in matchTiles)
        {
            if (_tiles[tileIndex.y, tileIndex.x] != null)
            {
                _tiles[tileIndex.y, tileIndex.x].View.DestroyTile();
                _tiles[tileIndex.y, tileIndex.x] = null;
            }
        }
    }
    private void CreateTile(int x, int y)
    {
        var tileName = Random.Range(0, _spriteCount);
        var tile = _tileFactory.CreateTile(_gridSpawnPoints[y, x], (TilesName)tileName);
        if (tile != null)
        {
            _tiles[y, x] = tile;
        }
    }
    private void CreateGrid()
    {
        _gridSpawnPoints = _gridCreater.CreateGridSpawnPoint();
    }
}
