using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 100;
    private Rigidbody2D _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }

    private void Jump()
    {
        if (Input.touchCount > 0 && !UIController.instance.isGameOver())
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
