using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 100;
    private Rigidbody2D _rb;
    private SpriteRenderer _sprite;
    private Color _colorOriginal;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
        _colorOriginal = _sprite.color;
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        ActualizarColor();
    }

    private void ActualizarColor()
    {
        if (UIController.instance.isStrong)
        {
            _sprite.color = Color.green;
        }else if (UIController.instance.useIman)
        {
            _sprite.color = Color.cyan;
        }
        else
        {
            _sprite.color = _colorOriginal;
        }
    }

    private void Jump()
    {
        if (Input.touchCount > 0 && !UIController.instance.isGameOver() && !UIController.instance.enPausa)
        {
            Touch toque = Input.GetTouch(0);
            if (toque.phase == TouchPhase.Began || toque.phase == TouchPhase.Stationary)
            {
                _rb.velocity = Vector2.zero;
                _rb.AddForce(Vector2.up * _jumpForce);
            }
        }
    }
}
