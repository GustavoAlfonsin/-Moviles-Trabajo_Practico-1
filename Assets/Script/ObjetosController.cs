using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetosController : MonoBehaviour
{
    [SerializeField] private float speed = 3f;

    // Update is called once per frame
    protected virtual void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x < -25f || UIController.instance.isGameOver())
        {
            Destroy(gameObject);
        }
    }
}
