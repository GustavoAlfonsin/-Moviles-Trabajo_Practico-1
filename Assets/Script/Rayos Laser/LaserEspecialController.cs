using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LaserEspecialController : MonoBehaviour
{
    public bool enMovimiento;
    [SerializeField] private float _inicio = 1.8f, _fin = -5.7f;
    [SerializeField] private float speed;

    private void Start()
    {
        enMovimiento = false;
    }

    private void Update()
    {
        if (enMovimiento)
        {
            Vector2 direccion = (_inicio < _fin) ? Vector2.up : Vector2.down;
            transform.Translate(direccion * speed * Time.deltaTime);
        }
    }

    public bool estaCerca()
    {
        return transform.position.y == _fin;
    }

    public void IniciarAtaque()
    {
        enMovimiento = true;
        transform.localPosition = new Vector2(transform.position.x, _inicio);
    }
}
