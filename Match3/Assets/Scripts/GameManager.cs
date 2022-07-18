using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TileSpritesView _tileSprites;
    [SerializeField] private TileView _tilePrefab;
    [SerializeField] private ScoreView _scoreView;

    private GameController _gameController;
    private GameData _gameData;
    private int _countPush = 0;

    private void Start()
    {
        _gameData = new GameData();
        _gameController = new GameController(_gameData, _tileSprites, _tilePrefab, _scoreView);
    }
    private void Update()
    {
        _gameController.Init();
        if (Input.GetMouseButtonDown(0))
        {
            _countPush++;
            if (_countPush == 2)
            {
                _gameController.ChangePositionMarked();
                _countPush = 0;
            }
        }
    }
}
