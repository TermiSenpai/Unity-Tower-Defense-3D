using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowTurretInfo : MonoBehaviour
{
    [SerializeField] UIPanelsManager uiPanels;
    [SerializeField] GameObject turretInfoPanel;

    [Header("Turret Info")]
    [SerializeField] TextMeshProUGUI turretName;
    [SerializeField] Image turretImage;
    [SerializeField] TextMeshProUGUI turretDamage;

    public void ShowInfo(Turret turret)
    {
        uiPanels.ChangePanel(turretInfoPanel);

        turretName.text = turret.turretName;
        turretDamage.text = turret.damage.ToString();
        turretImage.sprite = turret.turretImg;
    }
}
