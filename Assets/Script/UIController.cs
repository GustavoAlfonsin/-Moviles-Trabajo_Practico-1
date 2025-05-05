using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private int _puntos;
    [SerializeField] private TextMeshProUGUI _txtPuntos;

    public static UIController instance;
    // Start is called before the first frame update

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(this);
        }
    }
    void Start()
    {
        _puntos = 0;
        _txtPuntos.text = $"{_puntos}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActualizarPuntaje(int ptos)
    {
        _puntos += ptos;
        _txtPuntos.text = _puntos.ToString();
    }
}
