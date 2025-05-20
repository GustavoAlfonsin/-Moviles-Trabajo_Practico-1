using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LasersController : MonoBehaviour
{
    public GameObject[] _laseres;
    public GameObject[] _laserEspecial;
    private float _intervaloActivacion = 7.5f;
    private float timer;

    private void Start()
    {
        foreach (GameObject laser in _laseres) 
        {
            laser.SetActive(false);
        }
        foreach (GameObject laserEsp in _laserEspecial)
        {
            laserEsp.SetActive(false);
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
        int j = UnityEngine.Random.Range(0,2);
        j = 1;
        if (j == 0)
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
                _laseres[i].GetComponent<Animator>().Play("CargarLaser");
            }
        }
        else
        {
            int k = UnityEngine.Random.Range(0,_laserEspecial.Length);
            _laserEspecial[k].SetActive(true);
            _laserEspecial[k].GetComponent<LaserEspecialController>().IniciarAtaque();
            _laserEspecial[k].GetComponent<Animator>().Play("CargarLaser");
        }
        
    }
}
