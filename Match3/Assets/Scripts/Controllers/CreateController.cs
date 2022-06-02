using System.Collections.Generic;
using UnityEngine;

public class CreateController
{
    private readonly GameData _gameData;
    private readonly GridCreater _gridCreater;

    private Vector2[,] _gridSpawnPoints;
    private TileFactory _tileFactory;
    private Tile[,] _tiles = new Tile[GameData.GRID_X, GameData.GRID_Y];
    private int _spriteCount;

    public CreateController(GameData gameData, TileSpritesView tileSpritesView, TileView tileView, ScoreView scoreView)
    {
        _gameData = gameData;
        _gridCreater = new GridCreater(_gameData);
        var sprites = tileSpritesView.GetSprites();
        _spriteCount = sprites.Count;
        _tileFactory = new TileFactory(sprites, tileView, scoreView, _gameData);
    }

    public void Init()
    {
        CreateGrid();
        for (int y = 0; y < GameData.GRID_X; y++)
        {
            for (int x = 0; x < GameData.GRID_Y; x++)
            {
                CreateTileOnStart(x, y);
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
    public List<Tile> CreateTileOutOfScreen(List<Vector2Int> topEmptyTiles)
    {
        List<Tile> tilesOutOfScreen = new List<Tile>();
        foreach (var item in topEmptyTiles)
        {
            if (item != null)
            {
                var positionEmpty = _gridSpawnPoints[item.y, item.x];
                var positionY = positionEmpty.y + _gameData.PrefabSize.y + _gameData.Offset;
                var tileOutOfScreen = CreateTile(new Vector2(positionEmpty.x, positionY));
                tilesOutOfScreen.Add(tileOutOfScreen);
            }
        }
        return tilesOutOfScreen;
    }
    public bool ReplaseTileOnStart(List<Vector2Int> matchTiles)
    {
        bool isMatch = false;
        foreach (var tileIndex in matchTiles)
        {
            if (_tiles[tileIndex.y, tileIndex.x] != null)
            {
                isMatch = true;
                _tiles[tileIndex.y, tileIndex.x].View.DestroyTile(true);
                CreateTileOnStart(tileIndex.x, tileIndex.y);
            }
        }
        return isMatch;
    }
    public bool DectroyMatchedTiles(List<Vector2Int> matchTiles)
    {
        bool isMatch = false;
        foreach (var tileIndex in matchTiles)
        {
            if (_tiles[tileIndex.y, tileIndex.x] != null)
            {
                _tiles[tileIndex.y, tileIndex.x].View.DestroyTile(false);
                _tiles[tileIndex.y, tileIndex.x] = null;
                isMatch = true;
            }
        }
        return isMatch;
    }
    private void CreateTileOnStart(int x, int y)
    {
        var tile = CreateTile(_gridSpawnPoints[y, x]);
        if (tile != null)
        {
            _tiles[y, x] = tile;
        }
    }
    private Tile CreateTile(Vector2 tilePossition)
    {
        var tileName = Random.Range(0, _spriteCount);
        var tile = _tileFactory.CreateTile(tilePossition, (TilesName)tileName);
        return tile;
    }
    private void CreateGrid()
    {
        _gridSpawnPoints = _gridCreater.CreateGridSpawnPoint();
    }
}
