using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParedesController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!UIController.instance.isStrong)
            {
                Debug.Log("El jugador esta muerto");
                UIController.instance.isOver();
            }
        }
    }
}
