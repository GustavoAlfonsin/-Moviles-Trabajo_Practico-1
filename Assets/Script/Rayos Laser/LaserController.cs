using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    [SerializeField] private Animator _animatorIzq, _animatorDer;

    private void Start()
    {

    }
    public void ActivarLaser()
    {
        _animatorDer.Play("Recarga Laser");
        _animatorIzq.Play("Recarga Laser");
    }
}
