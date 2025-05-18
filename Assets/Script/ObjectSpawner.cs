using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _monedas;
    [SerializeField] private GameObject[] _enemigos;
    [SerializeField] private GameObject[] _powerUps;

    private Transform _spawPoint;
    private float yMaxEnemigo = 2f, yMaxMoneda = 2.5f;
    private float yMinEnemigo = -2f, yMinMoneda = -2.5f;

    [SerializeField] private float _spawInterval = 2f;
    private float timer = 0;

    [SerializeField] private float _PowerUpsInterval = 15f;
    private float timerPowerUps = 0;

    private void Start()
    {
        _spawPoint = this.transform;
    }
    private void Update()
    {
        if (!UIController.instance.isGameOver())
        {
            timer += Time.deltaTime;
            if (timer >= _spawInterval)
            {
                Debug.Log("ENTRO");
                SpawObject();
                timer = 0f;
                _spawInterval = Random.Range(2,5);
            }

            if (!powerUpActivo())
            {
                timerPowerUps += Time.deltaTime;
                if (timerPowerUps >= _PowerUpsInterval)
                {
                    spawPowerUp();
                    timerPowerUps = 0f;
                }
            }
        }
    }

    private bool powerUpActivo()
    {
        return UIController.instance.useIman || UIController.instance.isStrong;
    }

    private void SpawObject()
    {
        int i = UnityEngine.Random.Range(0,2);
        if (i == 0)
        {
            spawMoneda();
        }
        else
        {
            spawEnemigo();
        }
    }

    private void spawMoneda()
    {
        int index = Random.Range(0, _monedas.Length);
        Vector3 spawPos = _spawPoint.position + new Vector3(15, Random.Range(yMinMoneda,yMaxMoneda),0);
        Instantiate(_monedas[index], spawPos, Quaternion.identity, this.transform);
    }

    private void spawEnemigo()
    {
        int index = Random.Range(0, _enemigos.Length);
        Vector3 spawPos = _spawPoint.position + new Vector3(15, Random.Range(yMinEnemigo, yMaxEnemigo), 0);
        Instantiate(_enemigos[index], spawPos, Quaternion.identity, this.transform);
    }

    private void spawPowerUp()
    {
        int index = Random.Range(0, _powerUps.Length);
        Vector3 spawPos = _spawPoint.position + new Vector3(15, Random.Range(yMinMoneda, yMaxMoneda), 0);
        Instantiate(_powerUps[index], spawPos, Quaternion.identity, this.transform);
    }
}
