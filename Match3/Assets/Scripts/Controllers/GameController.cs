using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController
{
    private CreateController _createController;
    private TileCheckHandler _checkHandler;
    private TileMove _tileMove;



    public GameController(GameData gameData, TileSpritesView tileSpritesView, TileView tileView)
    {
        _createController = new CreateController(gameData, tileSpritesView, tileView);
        _checkHandler = new TileCheckHandler(gameData);
        _createController.Init();
        _tileMove = new TileMove(_createController.GetGridSpawnpoint());
        CheckMatchOnStart();

    }

    public void ChangePositionMarked()
    {
        var marked = _checkHandler.CheckMarked(_createController.GetTiles());
        if (marked != null)
        {
            _tileMove.ChangePosition(_createController.GetTiles(), marked);
            
        }
        ReplaceMatched();
    }
    private void ReplaceMatched()
    {
        _createController.DectroyMatchTiles(_checkHandler.CheckMatchGrid(_createController.GetTiles()));
    }
    private void CheckMatchOnStart()
    {
        while (true)
        {
            if (!_createController.ReplaseTileOnStart(_checkHandler.CheckMatchGrid(_createController.GetTiles())))
            {
                return;
            }
        }
    }

}
