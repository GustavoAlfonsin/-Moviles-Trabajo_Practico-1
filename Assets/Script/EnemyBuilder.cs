using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBuilder : ObjetosController
{
    // CONFIGURACIÓN ALEATORIA
    private float largoMin = 2f;
    private float LargoMax = 4f;
    private float offsetXMin = -0.5f;
    private float offsetXMax = 0.5f;

    [Header("Sprites y materiales")]
    [SerializeField] private Sprite esferaSprite;
    [SerializeField] private Material rayoMaterial;

    private Transform esferaSuperior, esferaInferior;
    private LineRenderer lineaRender;
    private BoxCollider2D boxCollider;

    private void Start()
    {
        ContruirEnemigoAleatorio();
    }

    protected override void Update()
    {
        base.Update();
        ActualizarRayo();
    }

    private void ContruirEnemigoAleatorio()
    {
        //Elegir valores aleatorios
        float largo = Random.Range(largoMin,LargoMax);
        float offSetX = Random.Range(offsetXMin,offsetXMax);

        //Crear esferas
        esferaInferior = CrearEsfera("EsferaInferior", new Vector2(0,-largo/2f), Color.red);
        esferaSuperior = CrearEsfera("EsferaSuperior", new Vector2(offSetX, largo/2f), Color.red);

        //Crear el rayo
        GameObject rayo = new GameObject("Rayo");
        rayo.transform.parent = transform;

        //LineRenderer visual
        lineaRender = rayo.AddComponent<LineRenderer>();
        lineaRender.material = rayoMaterial;
        lineaRender.startWidth = 0.05f;
        lineaRender.endWidth = 0.05f;
        lineaRender.positionCount = 2;
        lineaRender.useWorldSpace = true;

        //Collider
        boxCollider = rayo.AddComponent<BoxCollider2D>();
        boxCollider.isTrigger = true;
        rayo.AddComponent<ZonaLetal>();

        ActualizarRayo();
    }

    private Transform CrearEsfera(string name, Vector2 localPos, Color color)
    {
        GameObject go = new GameObject(name);
        go.transform.parent = transform;
        go.transform.localPosition = localPos;

        SpriteRenderer sr = go.AddComponent<SpriteRenderer>();
        sr.sprite = esferaSprite;
        sr.color = color;

        CircleCollider2D col = go.AddComponent<CircleCollider2D>();
        col.isTrigger = true;

        go.AddComponent<ZonaLetal>();

        return go.transform;
    }

    private void ActualizarRayo()
    {
        Vector2 posA = esferaSuperior.position;
        Vector2 posB = esferaInferior.position;

        //Linea visual
        lineaRender.SetPosition(0,posA);
        lineaRender.SetPosition(1,posB);

        //Collider
        Vector2 centro = (posA + posB) / 2f;
        Vector2 direccion = (posB - posA).normalized;
        float distancia = Vector2.Distance(posA,posB);

        Transform rayo = lineaRender.transform;
        rayo.position = centro;
        rayo.rotation = Quaternion.FromToRotation(Vector3.up,direccion);
        boxCollider.size = new Vector2(0.3f, distancia);
    }
}
