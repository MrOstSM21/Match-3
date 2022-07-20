
using System.Collections.Generic;
using UnityEngine;

public enum ControllerState
{
    Wait,
    CheckMatchOnStart,
    CheckMarked,
    ChangePositionMarkedTiles,
    ChangePositionMarkedTilesBack,
    CheckMatch,
    DestroyMatched,
    MoveTileDown,
    FillTopEmptyTiles

}

public class GameController
{
    private readonly CreateController _createController;
    private readonly TileCheckHandler _checkHandler;
    private readonly TileMove _tileMove;
    private readonly ScoreHandler _scoreHandler;

    private List<Vector2Int> _movingDownTiles;
    private List<Vector2Int> _markedTiles;
    private List<Vector2Int> _matchedTiles;
    private ControllerState _state;
    private Tile[,] _tiles;
    private bool _loop = false;
    private bool _isMoved;
    private bool _tilesExchange;

    public GameController(GameData gameData, TileSpritesView tileSpritesView, TileView tileView, ScoreView scoreView)
    {
        _scoreHandler = new ScoreHandler(scoreView);
        _createController = new CreateController(gameData, tileSpritesView, tileView, _scoreHandler);
        _checkHandler = new TileCheckHandler(gameData);
        _createController.Init();
        _tileMove = new TileMove(_createController.GetGridSpawnpoint, gameData);
        _state = ControllerState.CheckMatchOnStart;
        HandleState();
    }
    public void ChangePositionMarked()=> _state = ControllerState.CheckMarked;
   
    public void Init()
    {
        HandleState();
    }
    private void HandleState()
    {
        switch (_state)
        {
            case ControllerState.CheckMatchOnStart:

                var foundMatches = _checkHandler.CheckMatchGrid(_createController.GetTiles);
                if (!_createController.ReplaseTileOnStart(foundMatches))
                    _state = ControllerState.Wait;

                break;

            case ControllerState.CheckMarked:

                _markedTiles = _checkHandler.CheckMarked(_createController.GetTiles);
                if (_markedTiles.Count != 0)
                    _state = ControllerState.ChangePositionMarkedTiles;
                else
                    _state = ControllerState.Wait;

                break;

            case ControllerState.ChangePositionMarkedTiles:

                if (!_loop)
                {
                    _tileMove.ChangePosition(_createController.GetTiles, _markedTiles);
                    _tilesExchange = true;
                }
                CheckTileIsMove(_createController.GetTiles, ControllerState.CheckMatch, ControllerState.ChangePositionMarkedTiles);

                break;

            case ControllerState.CheckMatch:

                _matchedTiles = _checkHandler.CheckMatchGrid(_createController.GetTiles);
                if (_matchedTiles.Count != 0)
                {
                    _state = ControllerState.DestroyMatched;
                    _tilesExchange = false;
                }
                else if (_matchedTiles.Count == 0 && _tilesExchange)
                {
                    _state = ControllerState.ChangePositionMarkedTilesBack;
                    _tilesExchange = false;
                }

                else
                    _state = ControllerState.Wait;

                break;

            case ControllerState.ChangePositionMarkedTilesBack:

                if (!_loop)
                {
                    _tileMove.ChangePosition(_createController.GetTiles, _tileMove.GetRememberSwapTiles);
                }
                CheckTileIsMove(_createController.GetTiles, ControllerState.CheckMatch, ControllerState.ChangePositionMarkedTilesBack);

                break;

            case ControllerState.DestroyMatched:

                var destroyd = _createController.DectroyMatchedTiles(_matchedTiles);
                if (!destroyd)
                    _state = ControllerState.Wait;
                else
                    _state = ControllerState.MoveTileDown;

                break;

            case ControllerState.MoveTileDown:

                if (!_loop)
                {
                    _movingDownTiles = _checkHandler.FindMovingDownTiles(_createController.GetTiles);
                    _tiles = _createController.GetTiles;
                    _isMoved = _tileMove.MoveTileDown(_tiles, _movingDownTiles);
                }
                CheckTileIsMoveDown(_tiles, ControllerState.FillTopEmptyTiles, ControllerState.MoveTileDown);

                break;

            case ControllerState.FillTopEmptyTiles:

                var topEmptyTilesIndex = _checkHandler.FindTopEmptyTiles(_createController.GetTiles);
                if (topEmptyTilesIndex.Count == 0)
                {
                    _state = ControllerState.CheckMatch;
                }
                else
                {
                    var tileOutOfScreen = _createController.CreateTileOutOfScreen(topEmptyTilesIndex);
                    _tileMove.MoveDownNewTile(tileOutOfScreen, topEmptyTilesIndex, _createController.GetTiles);
                    _state = ControllerState.MoveTileDown;
                }

                break;

            default:
                break;
        }
    }
    private void CheckTileIsMove(Tile[,] tiles, ControllerState nextState, ControllerState currentState)
    {
        if (!_checkHandler.CheckTilesIsMove(tiles))
        {
            _state = nextState;
            _loop = false;
        }
        else
        {
            _state = currentState;
            _loop = true;
        }
    }
    private void CheckTileIsMoveDown(Tile[,] tiles, ControllerState nextState, ControllerState currentState)
    {
        var tilesIsMove = _checkHandler.CheckTilesIsMove(tiles);
        if (!_isMoved && !tilesIsMove)
        {
            _state = nextState;
            _loop = false;
        }
        else if (!_isMoved && tilesIsMove)
        {
            _state = currentState;
            _loop = true;
        }
        else if (_isMoved && tilesIsMove)
        {
            _state = _state = currentState;
            _loop = true;
        }
        else
        {
            _state = currentState;
            _loop = false;
        }
    }
}
