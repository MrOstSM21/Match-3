using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileView : MonoBehaviour
{
    [SerializeField] SpriteRenderer _sprite;
    public TilesName TilesName { get; private set; }
    public bool IsMatch { get; set; } = false;

    public void Init(Sprite sprite, TilesName tilesName)
    {
        _sprite.sprite = sprite;
        TilesName = tilesName;
    }
    public void DestroyTile()
    {
        Destroy(gameObject);
    }
}
