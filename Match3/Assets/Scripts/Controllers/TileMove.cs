using System.Collections.Generic;
using UnityEngine;

public class TileMove
{
    private Vector2[,] _tilesPosition;
    private Tile tempTile;
    private Vector2Int tempindex;
    private int count = 0;

    public TileMove(Vector2[,] tilesPosition)
    {
        _tilesPosition = tilesPosition;
    }
    public void ChangePosition(Tile[,] tiles, List<Vector2Int> indexMarked)
    {
        foreach (var item in indexMarked)
        {
            if (count == 0)
            {
                tempindex = item;
                tempTile = tiles[item.y, item.x];
                count++;
            }
            else
            {
                tiles[item.y, item.x].SetPosition(_tilesPosition[tempindex.y, tempindex.x]);
                tempTile.SetPosition(_tilesPosition[item.y, item.x]);
                Tile temp = tiles[item.y, item.x];
                tiles[item.y, item.x] = tiles[tempindex.y, tempindex.x];
                tiles[tempindex.y, tempindex.x] = temp;
                count = 0;
            }
        }
    }
    public bool MoveTileDown(Tile[,] tiles, List<Vector2Int> movingDownTiles)
    {
        bool isMatched = false;
        foreach (var item in movingDownTiles)
        {
            if (item != null)
            {
                tiles[item.y, item.x].SetPosition(_tilesPosition[item.y, item.x - 1]);
                tiles[item.y, item.x - 1] = tiles[item.y, item.x];
                tiles[item.y, item.x] = null;
                isMatched = true;
            }
        }
        return isMatched;
    }
    public void MoveDownNewTile(List<Tile> newTile, List<Vector2Int> topEmptyTilesIndex, Tile[,] tile)
    {
        if (newTile.Count == topEmptyTilesIndex.Count)
        {
            for (int index = 0; index < newTile.Count; index++)
            {
                var position = _tilesPosition[topEmptyTilesIndex[index].y, topEmptyTilesIndex[index].x];
                newTile[index].SetPosition(new Vector2(position.x, position.y));
                tile[topEmptyTilesIndex[index].y, topEmptyTilesIndex[index].x] = newTile[index];
            }
        }
    }
}
