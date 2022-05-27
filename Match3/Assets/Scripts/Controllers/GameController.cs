using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController
{
    private CreateController _createController;
    private TileCheckHandler _checkHandler;


    public GameController(GameData gameData, TileSpritesView tileSpritesView, TileView tileView)
    {
        _createController = new CreateController(gameData, tileSpritesView, tileView);
        _checkHandler = new TileCheckHandler(gameData);
        _createController.Init();
        CheckMatch();
    }
    private void CheckMatch()
    {
        while (true)
        {
            if (!_createController.ReplaseTile(_checkHandler.CheckMatchGrid(_createController.GetTilesView())))
            {
                return;
            }
        }
    }
}
