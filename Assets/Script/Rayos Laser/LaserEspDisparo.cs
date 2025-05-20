using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEspDisparo : StateMachineBehaviour
{
    public float tiempoDeDisparo = 2f;
    private float timer;
    private GameObject laserGo;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        laserGo = animator.gameObject;
        timer = 0;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;
        if (timer >= tiempoDeDisparo)
        {
            bool serca = animator.gameObject.GetComponent<LaserEspecialController>().estaCerca();
            if (serca)
            {
                laserGo.SetActive(false);
                animator.gameObject.GetComponent<LaserEspecialController>().enMovimiento = false;
            }
            else
            {
                animator.Play("CargarLaser");
            }
            
        }
    }
}
