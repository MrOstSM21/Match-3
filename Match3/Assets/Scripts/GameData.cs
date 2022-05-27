using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData 
{
    public const int GRID_X = 6;
    public const int GRID_Y = 7;
    public int TileOverlap { get; } = 2;
    public float Offset { get; } = 0.7f;
    public Vector3 StartPoint { get; } = new Vector3(-2.3f, -2.3f, 0f);
    public Vector3 PrefabSize { get; } = new Vector3(0.2f, 0.2f, 0f);
}
