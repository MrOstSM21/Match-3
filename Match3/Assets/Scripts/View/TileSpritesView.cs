using System.Collections.Generic;
using UnityEngine;

public class TileSpritesView : MonoBehaviour
{
    [SerializeField] private Sprite _red;
    [SerializeField] private Sprite _blue;
    [SerializeField] private Sprite _green;
    [SerializeField] private Sprite _yellow;
    public Dictionary<TilesName, Sprite> GetSprites()
    {
        return new Dictionary<TilesName, Sprite>
        {
            {TilesName.Red,_red },
            {TilesName.Blue,_blue },
            {TilesName.Green,_green },
            {TilesName.Yellow,_yellow },
        };
    }
}
