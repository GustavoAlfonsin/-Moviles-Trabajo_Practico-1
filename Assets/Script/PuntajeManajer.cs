using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class Puntaje
{
    public float monedas;
    public float distancia;

    public Puntaje(float monedas, float distancia)
    {
        this.monedas = monedas;
        this.distancia = distancia;
    }
}

public class PuntajeManajer : MonoBehaviour
{
    private string rutaArchivo;
    public Puntaje puntajeMax;
    public static PuntajeManajer instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        // Ruta donde se guardará el archivo JSON
        rutaArchivo = Path.Combine(Application.persistentDataPath, "puntaje.json");
        puntajeMax = CargarPuntaje();
    }

    public void GuardarPuntaje(Puntaje puntaje)
    {
        if (puntaje.monedas > puntajeMax.monedas)
        {
            string json = JsonUtility.ToJson(puntaje, true);
            File.WriteAllText(rutaArchivo, json);
            Debug.Log("Puntaje guardado en: " + rutaArchivo);
        }
    }

    public Puntaje CargarPuntaje()
    {
        if (File.Exists(rutaArchivo))
        {
            string json = File.ReadAllText(rutaArchivo);
            Puntaje puntaje = JsonUtility.FromJson<Puntaje>(json);
            Debug.Log("Puntaje cargado: " + puntaje.monedas + " monedas, " + puntaje.distancia + "m");
            return puntaje;
        }
        else
        {
            Debug.LogWarning("No se encontró el archivo de puntaje, se devuelve uno nuevo.");
            return new Puntaje(0, 0);
        }
    }
}
