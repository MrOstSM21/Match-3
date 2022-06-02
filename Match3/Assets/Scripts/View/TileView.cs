using System;
using UnityEngine;

public class TileView : MonoBehaviour
{
    public event Action IsPushed;
    public event Action IsDestroy;

    [SerializeField] SpriteRenderer _sprite;

    private bool _move;
    private Vector2 _position;
    public TilesName TilesName { get; private set; }

    private void Update()
    {
        if (_move)
        {
            transform.position = Vector2.MoveTowards(transform.position, _position, 0.04f);
        }
    }
    public void Init(Sprite sprite, TilesName tilesName)
    {
        _sprite.sprite = sprite;
        TilesName = tilesName;
    }
    public void OnMouseDown()
    {
        IsPushed?.Invoke();
    }
    public void DestroyTile(bool startDestroy)
    {
        if (!startDestroy)
        {
            IsDestroy?.Invoke();
        }
        
        Destroy(gameObject);
    }
    public void SetPosition(Vector2 position, bool move)
    {
        _move = move;
        _position = position;
    }
}
