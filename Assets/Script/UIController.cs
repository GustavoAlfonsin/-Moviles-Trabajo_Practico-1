using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class UIController : MonoBehaviour
{
    [SerializeField] private int _puntos;
    [SerializeField] private TextMeshProUGUI _txtPuntos;

    [SerializeField] private float _distanciaRecorrida;
    [SerializeField] private TextMeshProUGUI _txtDistacia;


    [Header("Panel de Game Over")]
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI GODistancia, GOPuntos;

    public static UIController instance;
    private bool gameOver;

    public Image barraEnergia;
    public float tiempoLlenado = 20f, tiempoVaciado = 10000f;

    private float energiaMaxima = 100f;
    private float velocidadNormal = 5f;
    private float velocidadMaxima = 30f;

    public float energia = 0f;
    public bool enBoost = false;
    // Start is called before the first frame update

    private void Awake()
    {
        if (instance != null && instance != this) 
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        _txtDistacia.gameObject.SetActive(true);
        _txtPuntos.gameObject.SetActive(true);
        gameOverPanel.SetActive(false);
        gameOver = false;
        enBoost = false;
        energia = 0;
        _puntos = 0;
        _txtPuntos.text = $"{_puntos}";
        _distanciaRecorrida = 0;
        _txtDistacia.text = _distanciaRecorrida.ToString() + " km";
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            float delta = Time.deltaTime;
            if (enBoost)
            {
                energia -= tiempoVaciado * delta;
                if (energia <= 0f)
                {
                    energia = 0;
                    enBoost = false;
                }
                _distanciaRecorrida += velocidadMaxima * delta;
                _txtDistacia.text = _distanciaRecorrida.ToString("F2") + " km";
            }
            else
            {
                energia += tiempoLlenado * delta;
                energia = Mathf.Clamp(energia, 0f, energiaMaxima);

                _distanciaRecorrida += velocidadNormal * delta;
                _txtDistacia.text = _distanciaRecorrida.ToString("F2") + " km";

                if (Input.acceleration.x > 0.3f && energia >= energiaMaxima)
                {
                    enBoost = true;
                }
            }
            if (barraEnergia != null)
            {
                float porcentaje = energia / energiaMaxima;
                barraEnergia.fillAmount = porcentaje;
                barraEnergia.color = Color.Lerp(Color.red, Color.green, porcentaje);
            }
            
        }
    }

    public void ActualizarPuntaje(int ptos)
    {
        _puntos += ptos;
        _txtPuntos.text = _puntos.ToString();
    }

    public void ActualizarDistancia(int mtros)
    {
        _distanciaRecorrida += mtros;
        _txtDistacia.text = _distanciaRecorrida.ToString() + " km";
    }

    public bool isGameOver()
    {
        return gameOver;
    }

    public void isOver()
    {
        gameOver = true;
        _txtDistacia.gameObject.SetActive(false);
        _txtPuntos.gameObject.SetActive(false);
        gameOverPanel.SetActive(true);
        GODistancia.text = $"{_distanciaRecorrida} km";
        GOPuntos.text = $"Monedas: {_puntos}";
    }

    public void ReiniciarEscena()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameOver = false;
        _txtDistacia.gameObject.SetActive(true);
        _txtPuntos.gameObject.SetActive(true);
        gameOverPanel.SetActive(false);
        _puntos = 0;
        _txtPuntos.text = $"{_puntos}";
        _distanciaRecorrida = 0;
        _txtDistacia.text = _distanciaRecorrida.ToString() + " km";
        energia = 0;
    }

    public void IrAlMenu()
    {
        SceneManager.LoadScene("Inicio");
    }
}
