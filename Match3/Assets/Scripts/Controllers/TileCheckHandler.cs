using System.Collections.Generic;
using UnityEngine;

public class TileCheckHandler
{
    private readonly GameData _gameData;

    private Tile[,] _tiles;
    private int _matchCount = 0;

    public TileCheckHandler(GameData gameData)
    {
        _gameData = gameData;
    }
    public List<Vector2Int> CheckMatchGrid(Tile[,] tiles)
    {
        _tiles = tiles;
        List<Vector2Int> _matchedTilesIndex = new List<Vector2Int>();

        Vector2Int dirrectionLeft = new Vector2Int(-1, 0);
        Vector2Int dirrectionRight = new Vector2Int(1, 0);
        Vector2Int dirrectionUp = new Vector2Int(0, -1);
        Vector2Int dirrectionDown = new Vector2Int(0, 1);

        for (int y = 0; y < GameData.GRID_X; y++)
        {
            for (int x = 0; x < GameData.GRID_Y; x++)
            {
                CheckMatch(x, y, dirrectionLeft.x, dirrectionLeft.y);
                ResetMatchCount();
                CheckMatch(x, y, dirrectionRight.x, dirrectionRight.y);
                ResetMatchCount();
                CheckMatch(x, y, dirrectionUp.x, dirrectionUp.y);
                ResetMatchCount();
                CheckMatch(x, y, dirrectionDown.x, dirrectionDown.y);
                ResetMatchCount();
            }
        }
        AddMatchedTile(_matchedTilesIndex);
        return _matchedTilesIndex;
    }
    public List<Vector2Int> CheckMarked(Tile[,] tiles)
    {
        List<Vector2Int> _markedTilesIndex = new List<Vector2Int>();

        for (int y = 0; y < GameData.GRID_X; y++)
        {
            for (int x = 0; x < GameData.GRID_Y; x++)
            {
                if (tiles[y, x]._isMark)
                {
                    _markedTilesIndex.Add(new Vector2Int(x, y));
                }
            }
        }

        if (_markedTilesIndex.Count == 2 && CheckPositionMarked(_markedTilesIndex))
        {
            return _markedTilesIndex;
        }
        else
        {
            foreach (var item in _markedTilesIndex)
            {
                if (item != null)
                {
                    tiles[item.y, item.x]._isMark = false;
                }
            }
        }
        return new List<Vector2Int>();

    }
    public List<Vector2Int> FindMovingDownTiles(Tile[,] tiles)
    {
        List<Vector2Int> movingDownTilesIndex = new List<Vector2Int>();
        for (int y = 0; y < GameData.GRID_X; y++)
        {
            for (int x = 0; x < GameData.GRID_Y; x++)
            {
                if (tiles[y, x] == null && x + 1 < GameData.GRID_Y && tiles[y, x + 1] != null)
                {
                    movingDownTilesIndex.Add(new Vector2Int(x + 1, y));
                }
            }
        }
        return movingDownTilesIndex;
    }
    public List<Vector2Int> FindTopEmptyTiles(Tile[,] tiles)
    {
        List<Vector2Int> topEmptyTilesIndex = new List<Vector2Int>();
        for (int y = 0; y < GameData.GRID_X; y++)
        {
            for (int x = 0; x < GameData.GRID_Y; x++)
            {
                if (tiles[y, x] == null && x == GameData.GRID_Y - 1)
                {
                    topEmptyTilesIndex.Add(new Vector2Int(x, y));
                }
            }
        }
        return topEmptyTilesIndex;
    }
    private void CheckMatch(int x, int y, int xOffset, int yOffset)
    {
        if (CheckIndex(x, GameData.GRID_Y, xOffset) && CheckIndex(y, GameData.GRID_X, yOffset))
        {
            if (_tiles[y, x].TilesName == _tiles[y + yOffset, x + xOffset].TilesName)
            {
                _matchCount++;

                CheckMatch(x + xOffset, y + yOffset, xOffset, yOffset);
                if (_matchCount >= _gameData.TileOverlap)
                {
                    _tiles[y, x]._isMatch = true;

                }
            }
            return;
        }
        else
        {
            return;
        }
    }
    private bool CheckIndex(int index, int gridDirrectionLenght, int offset)
    {
        if (index >= 0 && index < gridDirrectionLenght && index + offset >= 0 && index + offset < gridDirrectionLenght)
        {
            return true;
        }
        return false;
    }
    private void AddMatchedTile(List<Vector2Int> matchedTilesIndex)
    {
        for (int y = 0; y < GameData.GRID_X; y++)
        {
            for (int x = 0; x < GameData.GRID_Y; x++)
            {
                if (_tiles[y, x]._isMatch)
                {
                    matchedTilesIndex.Add(new Vector2Int(x, y));
                }
            }
        }
    }
    private void ResetMatchCount()
    {
        _matchCount = 0;
    }
    private bool CheckPositionMarked(List<Vector2Int> marked)
    {
        Vector2Int index = new Vector2Int(0, 0);
        var indexNumber = 0;
        foreach (var item in marked)
        {
            if (indexNumber == 0)
            {
                index = item;
                indexNumber++;
            }
            else if (indexNumber == 1)
            {
                if (index.y == item.y - 1 && index.x == item.x)
                {
                    return true;
                }
                else if (index.y == item.y && index.x == item.x - 1)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
