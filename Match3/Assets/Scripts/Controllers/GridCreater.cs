using UnityEngine;

public class GridCreater
{
    private readonly GameData _gameData;
    private Vector2[,] _spawnPoint;

    public GridCreater(GameData gameData)
    {
        _gameData = gameData;
    }
    public Vector2[,] CreateGridSpawnPoint()
    {
        _spawnPoint = new Vector2[GameData.GRID_X, GameData.GRID_Y];

        Vector2 _stepGrid;
        _stepGrid.x = _gameData.PrefabSize.x + _gameData.Offset;
        _stepGrid.y = _gameData.PrefabSize.y + _gameData.Offset;


        for (int y = 0; y < GameData.GRID_Y; y++)
        {
            for (int x = 0; x < GameData.GRID_X; x++)
            {
                var position = new Vector3(_gameData.StartPoint.x + (_stepGrid.x * x), _gameData.StartPoint.y + (_stepGrid.y * y), 0);
                _spawnPoint[x, y] = position;
            }
        }

        return _spawnPoint;
    }
}
