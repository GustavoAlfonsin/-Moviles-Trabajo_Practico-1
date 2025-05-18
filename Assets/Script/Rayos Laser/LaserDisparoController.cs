using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LaserDisparoController : StateMachineBehaviour
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
            laserGo.SetActive(false);
        }
    }
}
