using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaLetal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("El jugador esta muerto");
            UIController.instance.isOver();
        }
    }
}
