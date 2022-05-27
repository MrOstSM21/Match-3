using System.Collections.Generic;
using UnityEngine;

public class TileCheckHandler
{
    private TileView[,] _tilesView;
    private List<Vector2Int> _matchedTiles = new List<Vector2Int>();
    private GameData _gameData;
    private int _matchCount = 0;


    public TileCheckHandler(GameData gameData)
    {

        _gameData = gameData;
    }
    public List<Vector2Int> CheckMatchGrid(TileView[,] tileViews)
    {
        _tilesView = tileViews;
        _matchedTiles.Clear();

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
        AddMatchedTile();
        return _matchedTiles;
    }
    private void CheckMatch(int x, int y, int xOffset, int yOffset)
    {

        if (CheckIndex(x, GameData.GRID_Y, xOffset) && CheckIndex(y, GameData.GRID_X, yOffset))
        {
            if (_tilesView[y, x].TilesName == _tilesView[y + yOffset, x + xOffset].TilesName)
            {
                _matchCount++;
                CheckMatch(x + xOffset, y + yOffset, xOffset, yOffset);
            }
            else
            {
                if (_matchCount >= _gameData.TileOverlap)
                {
                    _tilesView[y, x].IsMatch = true;
                }
                return;
            }
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
    private void AddMatchedTile()
    {
        for (int y = 0; y < GameData.GRID_X; y++)
        {
            for (int x = 0; x < GameData.GRID_Y; x++)
            {
                if (_tilesView[y, x].IsMatch)
                {
                    _matchedTiles.Add(new Vector2Int(x, y));
                }
            }
        }
    }
    private void ResetMatchCount()
    {
        _matchCount = 0;
    }
}
