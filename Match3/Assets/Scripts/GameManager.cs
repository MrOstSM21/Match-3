using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TileSpritesView _tileSprites;
    [SerializeField] private TileView _tilePrefab;
        private GameController _gameController;
    private int _countPush = 0;
    private GameData _gameData;
    private void Start()
    {
        _gameData = new GameData();
        _gameController = new GameController(_gameData,_tileSprites , _tilePrefab);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _countPush++;
            if (_countPush==2)
            {
                Debug.Log(" push 2 count, start check"); 
                _gameController.ChangePositionMarked();
                _countPush = 0;
            }
            
        }
    }
}
