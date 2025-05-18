using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public enum TypeOfPowerUps
{
    Invulnerabilidad,
    Iman
}

public class PowerUpsController : ObjetosController
{
    [SerializeField] private TypeOfPowerUps powerType;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            switch (powerType)
            {
                case TypeOfPowerUps.Invulnerabilidad:
                    UIController.instance.isStrong = true;
                    break;
                case TypeOfPowerUps.Iman:
                    UIController.instance.useIman = true;
                    break;
                default:
                    break;
            }
            Destroy(gameObject);
        }
    }
}
