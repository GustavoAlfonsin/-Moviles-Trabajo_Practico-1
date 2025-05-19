using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class EnemigoSaltarinController : ObjetosController
{
    [SerializeField] float verticalSpeed = 2f;
    public LayerMask capaTechoPiso;
    [SerializeField] float distanciaDeteccion = 0.1f;
    [SerializeField] Vector2 tamañoCajaDeteccion = new Vector2(0.5f,0.5f);

    [SerializeField] private bool subiendo = false;

    private void Start()
    {
    }

    protected override void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        Vector2 direccion = subiendo ? Vector2.up : Vector2.down;
        transform.Translate(direccion * verticalSpeed * Time.deltaTime);

        VerificarColisionesVerticales();
    }

    private void VerificarColisionesVerticales()
    {
        Vector2 origen = transform.position;
        Vector2 direccion = subiendo ? Vector2.up : Vector2.down;

        RaycastHit2D hit = Physics2D.BoxCast(origen, tamañoCajaDeteccion, 0f,direccion, distanciaDeteccion, capaTechoPiso) ;

        if (hit.collider != null && hit.collider.CompareTag("Pared"))
        {
            subiendo = !subiendo;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Vector2 origen = transform.position;
        Vector2 direccion = subiendo ? Vector2.up : Vector2.down;
        Gizmos.DrawWireCube(transform.position + (Vector3)(direccion * distanciaDeteccion), tamañoCajaDeteccion);
    }
}
