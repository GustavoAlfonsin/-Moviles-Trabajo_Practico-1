using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonedaController : MonoBehaviour
{
    [SerializeField] private int valor = 1;

    private void Update()
    {
        if (UIController.instance.useIman)
        {
            if (transform.position.x <= -6)
            {
                UIController.instance.ActualizarPuntaje(valor);
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UIController.instance.ActualizarPuntaje(valor);
            Destroy(gameObject);
        }
    }
}
