using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] UISoundsManager UI_SoundsManager;
    [SerializeField] UIPanelsManager UI_PanelsManager;
    [SerializeField] AudioClip errorSound;
    [SerializeField] AudioClip BuySound;

    public void PurchaseTurret(Turret turret)
    {
        if (Currency.Money >= turret.cost)
        {
            BuildManager.instance.SetTurretToBuild(turret);
            UI_PanelsManager.ClosePanel();
            UI_SoundsManager.PlayUISound(BuySound);
            Debug.Log($"The {turret} has been purchased");
        }
        else
        {
            UI_SoundsManager.PlayUISound(errorSound);
        }
    }
}
