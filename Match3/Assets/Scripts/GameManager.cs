using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TileSpritesView _tileSprites;
    [SerializeField] private TileView _tilePrefab;
    private GameController _gameController;
    private GameData _gameData;
    private void Start()
    {
        _gameData = new GameData();
        _gameController = new GameController(_gameData,_tileSprites , _tilePrefab);
    }
}
