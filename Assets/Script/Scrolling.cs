using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
    public float scrollNormalSpeed;
    public float scrollFastSpeed;
    public float scrollOfset;

    Vector2 startPosition;
    float newPos;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        float speed;
        if (UIController.instance != null)
        {
            speed = UIController.instance.enBoost ? scrollFastSpeed : scrollNormalSpeed;
        }
        else
        {
            speed = scrollNormalSpeed;
        }

        if (UIController.instance == null || !UIController.instance.isGameOver())
        {
            newPos = Mathf.Repeat(Time.time * -speed,scrollOfset);
            transform.position = startPosition + Vector2.right * newPos;
        }
    }
}
