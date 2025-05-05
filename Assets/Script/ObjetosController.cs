using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetosController : MonoBehaviour
{
    [SerializeField] private float speed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x < -25f)
        {
            Destroy(gameObject);
        }
    }
}
