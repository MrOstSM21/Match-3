using System;
using UnityEngine;
using System.Collections;

public class TileView : MonoBehaviour
{
    public event Action IsPushed;
    public event Action IsDestroy;

    [SerializeField] SpriteRenderer _sprite;

    private bool _isMove;
    private Vector3 _position;
    private float _speed;
    public TilesName TilesName { get; private set; }

    private void Update()
    {
        if (_isMove)
        {
            transform.position = Vector2.MoveTowards (transform.position, _position, _speed);

            if (transform.position == _position)
            {
                _isMove = false;
            }
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
    public void SetPosition(Vector2 position, bool move, float speed)
    {
        _speed = speed;
        _isMove = move;
        _position = position;

    }
    public bool GetIsMove()
    {
        return _isMove;
    }

}
