using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LasersController : MonoBehaviour
{
    public GameObject[] _laseres;
    private float _intervaloActivacion = 3f;
    private float timer;

    private void Start()
    {
        foreach (GameObject laser in _laseres) 
        {
            laser.SetActive(false);
        }
        timer = 0;
    }

    private void Update()
    {
        if (!UIController.instance.isGameOver()) 
        {
            timer += Time.deltaTime;
            if (timer >= _intervaloActivacion)
            {
                activarLaseres();
                timer = 0;
            }
        }
       
    }

    private void activarLaseres()
    {
        List<int> elegidos = new List<int>();
        while (elegidos.Count < 3) 
        {
            int i;
            do
            {
                i = UnityEngine.Random.Range(0, _laseres.Length);
            } while (elegidos.Contains(i));
            elegidos.Add(i);
        }

        foreach (int i in elegidos)
        {
            _laseres[i].SetActive(true);
            _laseres[i].GetComponent<LaserController>().ActivarLaser();
        }
    }
}
