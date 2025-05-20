using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlTutorial : MonoBehaviour
{
    [SerializeField] private List<Sprite> paginasTutorial;

    private int index;
    private Image _imagen;

    private void Start()
    {
        _imagen = GetComponent<Image>();
        index = 0;
    }

    public void paginaSiguiente()
    {
        index++;
        if (index >= paginasTutorial.Count)
        {
            index = 0;
        }
        _imagen.sprite = paginasTutorial[index];
    }

    public void paginaAnterior()
    {
        index--;
        if (index < 0)
        {
            index = paginasTutorial.Count - 1;
        }
        _imagen.sprite = paginasTutorial[index];
    }
}
