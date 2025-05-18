using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCargaController : StateMachineBehaviour
{
    private GameObject _laserBody;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _laserBody = animator.gameObject.transform.Find("LaserBody")?.gameObject;

        if (_laserBody != null)
        {
            Debug.Log("Encontro el laser");
            _laserBody.SetActive(false);
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_laserBody != null)
        {
            _laserBody.SetActive(true);
        }
    }
}
