using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowTurretInfo : MonoBehaviour
{
    [SerializeField] UIPanelsManager uiPanels;
    [SerializeField] GameObject turretInfoPanel;
    [SerializeField] GameObject upgradeBtn;

    [Header("Turret Info")]
    [SerializeField] TextMeshProUGUI turretName;
    [SerializeField] Image turretImage;
    [SerializeField] TextMeshProUGUI turretDamage;
    [SerializeField] TextMeshProUGUI turretDescription;

    [Space, Header("Currency info")]
    [SerializeField] TextMeshProUGUI upgradeCostTxt;
    [SerializeField] TextMeshProUGUI sellValueTxt;


    public void ShowInfo(Turret turret)
    {
        uiPanels.ChangePanel(turretInfoPanel);

        turretName.text = turret.turretName;
        turretDamage.text = turret.damage.ToString();
        turretImage.sprite = turret.turretImg;
        turretDescription.text = turret.attackDescription;

        if (turret.nextLevel == null)
        {
            upgradeBtn.SetActive(false);
            upgradeCostTxt.text = string.Empty;
        }
        else
        {
            upgradeBtn.SetActive(true);
            upgradeCostTxt.text = $"Upgrade cost: ${turret.upgradeCost}";
        }

        sellValueTxt.text = $"Sell ${turret.sellValue}";
    }
}
