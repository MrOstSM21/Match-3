using System.Collections.Generic;
using UnityEngine;

public enum TilesName
{
    Red,
    Blue,
    Green,
    Yellow
}
public class TileFactory
{
    private readonly Dictionary<TilesName, Sprite> _sprites;
    private readonly TileView _prefab;
    private readonly ScoreView _scoreView;
    private readonly GameData _gameData;

    public TileFactory(Dictionary<TilesName, Sprite> sprites, TileView prefab,ScoreView scoreView,GameData gameData)
    {
        _sprites = sprites;
        _prefab = prefab;
        _scoreView = scoreView;
        _gameData = gameData;
    }

    public Tile CreateTile(Vector2 tilePosition, TilesName tileName)
    {
        var tileView = Object.Instantiate(_prefab, tilePosition, Quaternion.identity);
        tileView.Init(_sprites[tileName], tileName);
        var tile = new Tile(tileView,_scoreView,_gameData);
        return tile;
    }
}
