using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    public const int GRID_X = 6;
    public const int GRID_Y = 7;
    public int TileOverlap { get; } = 2;
    public float Offset { get; } = 0.6f;
    public float SwapTileSpeed { get; } = 0.004f;
    public float MoveTileSpeed { get; } = 0.04f;
    public Vector3 StartPoint { get; } = new Vector3(-2.0f, -2.3f, 0f);
    public Vector3 PrefabSize { get; } = new Vector3(0.2f, 0.2f, 0f);

    public Dictionary<TilesName, int> GetPoints { get; } = new Dictionary<TilesName, int>()
    {
        { TilesName.Red,1 },
        { TilesName.Blue,1 },
        { TilesName.Green,1 },
        { TilesName.Yellow,1 }

    };
}
