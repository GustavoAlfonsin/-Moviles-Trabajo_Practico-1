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
    private float posicionX = 20f;

    [Header("Monedas")]
    public GameObject monedaPrefab;
    [SerializeField] private float tiempoEntreMonedas = 5f;
    [SerializeField] private float tiempoSiguienteMoneda = 3f;
    public PatronMonedas[] patrones;

    [Header("Enemigos")]
    public GameObject prefabEnemigos;
    private float tiempoEntreEnemigos = 4f;
    private float tiempoSiguienteEnemigo = 3f;

    [Header("Grilla")]
    public float espacioVertival = 1f;
    public float espacioHorizontal = 1f;
    public int filasVisibles = 7;

    private List<Vector2> celdasOcupadas = new();

    private void Update()
    {
        celdasOcupadas.Clear();

        if (Time.time >= tiempoSiguienteMoneda)
        {
            SpawMonedas();
            tiempoSiguienteMoneda = Time.time + tiempoEntreMonedas;
        }

        if (Time.time >= tiempoSiguienteEnemigo)
        {
            SpawEnemigo();
            tiempoSiguienteEnemigo = Time.time + tiempoEntreEnemigos;
        }
    }

    private void SpawMonedas()
    {
        if (patrones.Length == 0) return;

        PatronMonedas patron = patrones[Random.Range(0, patrones.Length)];

        int maxIntentos = 10;
        int intentos = 0;
        Vector2 origen = Vector2.zero;

        while (intentos < maxIntentos)
        {
            int filaBase = Random.Range(1, filasVisibles - 2);
            origen = new Vector2(0, filaBase);

            bool hayColision = false;
            foreach (Vector2 offset in patron.posicionesRelativas)
            {
                Vector2 celda = origen + offset;
                if (celdasOcupadas.Contains(celda))
                {
                    hayColision = true;
                    break;
                }
            }
            if (!hayColision) break;

            intentos++;
        }

        foreach (Vector2 offset in patron.posicionesRelativas)
        {
            Vector2 celda = origen + offset;
            celdasOcupadas.Add(celda);

            Vector2 posicion = new Vector2(
                posicionX + offset.x * espacioHorizontal,
                (celda.y - filasVisibles/2)*espacioVertival
                );

            GameObject moneda = Instantiate(monedaPrefab, posicion, Quaternion.identity);
        }
    }

    private void SpawEnemigo()
    {
        int filaCentro;
        int intentos = 0;
        int maxIntentos = 10;

        do
        {
            filaCentro = Random.Range(1, filasVisibles -2);
        } while ((celdasOcupadas.Contains(new Vector2Int(0, filaCentro - 1)) ||
             celdasOcupadas.Contains(new Vector2Int(0, filaCentro)) ||
             celdasOcupadas.Contains(new Vector2Int(0, filaCentro + 1)))
            && intentos < maxIntentos);

        celdasOcupadas.Add(new Vector2Int(0, filaCentro - 1));
        celdasOcupadas.Add(new Vector2Int(0, filaCentro));
        celdasOcupadas.Add(new Vector2Int(0, filaCentro + 1));

        Vector3 posicion = new Vector3(posicionX, (filaCentro - filasVisibles /2) * espacioVertival,0);

        GameObject enemigo = Instantiate(prefabEnemigos, posicion, Quaternion.identity);
    }

}
