
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
        ReplaceEmpty();
    }
    private void ReplaceEmpty()
    {
        while (true)
        {
            var destroyd = _createController.DectroyMatchedTiles(_checkHandler.CheckMatchGrid(_createController.GetTiles()));
            if (!destroyd)
            {
                return;
            }
            FillEmpty();
        }
    }
    private void FillEmpty()
    {
        while (true)
        {
            while (true)
            {
                if (!_tileMove.MoveTileDown(_createController.GetTiles(), _checkHandler.FindMovingDownTiles(_createController.GetTiles())))
                {
                    break;
                }
            }
            var topEmptyTilesIndex = _checkHandler.FindTopEmptyTiles(_createController.GetTiles());
            if (topEmptyTilesIndex.Count == 0)
            {
                return;
            }
            _tileMove.MoveDownNewTile(_createController.CreateTileOutOfScreen(topEmptyTilesIndex), topEmptyTilesIndex, _createController.GetTiles());
        }

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
