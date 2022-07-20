using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TileSpritesView _tileSprites;
    [SerializeField] private TileView _tilePrefab;
    [SerializeField] private ScoreView _scoreView;
    [SerializeField] private TimerView _timerView;

    private GameController _gameController;
    private GameData _gameData;
    private TimeHandler _timeHandler;
    private int _countPush = 0;

    private void Start()
    {
        _gameData = new GameData();
        _timeHandler = new TimeHandler(_timerView);
        _gameController = new GameController(_gameData, _tileSprites, _tilePrefab, _scoreView);
    }
    private void Update()
    {
        _gameController.Init();
        if (Input.GetMouseButtonDown(0) && !_timeHandler.GameIsStop)
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
