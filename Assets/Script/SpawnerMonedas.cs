using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PatronMonedas
{
    public string nombre;
    public Vector2[] posicionesRelativas;
}

public class SpawnerMonedas : MonoBehaviour
{
    public GameObject monedaPrefab;
    [SerializeField] private float tiempoEntreSpawns = 5f;
    public float posicionX = 20f;

    public PatronMonedas[] patrones;
    [SerializeField] private float tiempoSiguienteSpawn = 3f;

    private void Update()
    {
        if (Time.time >= tiempoSiguienteSpawn)
        {
            SpawPatronAleatorio();
            tiempoSiguienteSpawn = Time.time + tiempoEntreSpawns;
        }
    }

    private void SpawPatronAleatorio()
    {
        if (patrones.Length == 0) return;

        PatronMonedas patron = patrones[Random.Range(0,patrones.Length)];
        float alturaBase = Random.Range(-2.5f,2.5f);

        foreach (Vector2 offset in patron.posicionesRelativas)
        {
            Vector2 posicion = new Vector2(posicionX + offset.x, alturaBase + offset.y);
            Instantiate(monedaPrefab, posicion, Quaternion.identity);
        }
    }
}
