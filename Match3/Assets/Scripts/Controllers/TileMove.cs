using System.Collections.Generic;
using UnityEngine;

public class TileMove
{
    public List<Vector2Int> GetRememberSwapTiles { get { return _indexMovedTiles; } }

    private readonly Vector2[,] _tilesPosition;

    private List<Vector2Int> _indexMovedTiles = new List<Vector2Int>();
    private Vector2Int _firstTileindex;
    private Tile _firstTile;
    private Tile _secondTile;
    private int count = 0;

    public TileMove(Vector2[,] tilesPosition)
    {
        _tilesPosition = tilesPosition;
    }
    public void ChangePosition(Tile[,] tiles, List<Vector2Int> indexMarked)
    {
        for (int i = 0; i < 2; i++)
        {
            if (i == 0)
            {
                _firstTileindex = indexMarked[0];
                _firstTile = tiles[indexMarked[0].y, indexMarked[0].x];
                count++;
            }
            else
            {
                var secondTileIndex = indexMarked[1];
                tiles[secondTileIndex.y, secondTileIndex.x].SetTileViewSwap(_tilesPosition[_firstTileindex.y, _firstTileindex.x]);
                _firstTile.SetTileViewSwap(_tilesPosition[secondTileIndex.y, secondTileIndex.x]);
                _secondTile = tiles[secondTileIndex.y, secondTileIndex.x];
                tiles[secondTileIndex.y, secondTileIndex.x] = tiles[_firstTileindex.y, _firstTileindex.x];
                tiles[_firstTileindex.y, _firstTileindex.x] = _secondTile;
                count = 0;
                RememberTilesMoved(new Vector2Int(secondTileIndex.x, secondTileIndex.y), new Vector2Int(_firstTileindex.x, _firstTileindex.y));

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
                tiles[item.y, item.x].SetTileViewMove(_tilesPosition[item.y, item.x - 1]);
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
                newTile[index].SetTileViewMove(new Vector2(position.x, position.y));
                tile[topEmptyTilesIndex[index].y, topEmptyTilesIndex[index].x] = newTile[index];
            }
        }
    }

    private void RememberTilesMoved(Vector2Int firstIndex, Vector2Int secondIndex)
    {
        _indexMovedTiles.Clear();
        _indexMovedTiles.Add(firstIndex);
        _indexMovedTiles.Add(secondIndex);
    }
}

