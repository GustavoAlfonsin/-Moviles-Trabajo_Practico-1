using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
            _distanciaRecorrida += 25 * Time.deltaTime;
            _txtDistacia.text = _distanciaRecorrida.ToString() + " km";
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
        _distanciaRecorrida = 0;
    }

    public void IrAlMenu()
    {
        Debug.Log("Volver al menú");
    }
}
