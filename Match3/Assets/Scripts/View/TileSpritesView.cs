using System.Collections.Generic;
using UnityEngine;

public class TileSpritesView : MonoBehaviour
{
    [SerializeField] private Sprite _coin;
    [SerializeField] private Sprite _meat;
    [SerializeField] private Sprite _gem;
    [SerializeField] private Sprite _crown;
    public Dictionary<TilesName, Sprite> GetSprites()
    {
        return new Dictionary<TilesName, Sprite>
        {
            {TilesName.Coin,_coin },
            {TilesName.Meat,_meat },
            {TilesName.Gem,_gem },
            {TilesName.Crown,_crown },
        };
    }
}
