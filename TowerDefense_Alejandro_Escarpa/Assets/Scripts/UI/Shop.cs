using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Shop : MonoBehaviour
{

    public void PurchaseTurret(Turret turret)
    {
        if (Currency.Money >= turret.cost)
        {
            BuildManager.instance.SetTurretToBuild(turret);
            Debug.Log($"The {turret} has been purchased");
        }
    }
}
