using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileView : MonoBehaviour
{
    public event Action IsPushed;

    [SerializeField] SpriteRenderer _sprite;
    public TilesName TilesName { get; private set; }
   
    public void Init(Sprite sprite, TilesName tilesName)
    {
        _sprite.sprite = sprite;
        TilesName = tilesName;
    }
    public void OnMouseDown()
    {
        IsPushed?.Invoke();
    }
    public void DestroyTile()
    {
        Destroy(gameObject);
    }
    public void SetPosition(Vector2 position)
    {
        transform.position = position;
    }
}
