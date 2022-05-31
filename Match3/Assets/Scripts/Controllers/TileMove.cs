using System.Collections;
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
    public void MoveTileDown(Tile[,] tiles)
    {

    }
}
