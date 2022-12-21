using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager instance;
    [SerializeField] UIPanelsManager uiPanel;

    GroundSelector selectedGround;
    Turret selectedTurret;
    BuildManager buildManager;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one UpgradeManager in scene");
        }
        instance = this;
    }

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void UpdateSelectedTurret(Turret newTurret)
    {
        selectedTurret = newTurret;
    }


    public void UpdateGround(GroundSelector ground)
    {
        selectedGround = ground;
    }

    public void UpdateReferences(GroundSelector newGround, Turret newTurret)
    {
        UpdateSelectedTurret(newTurret);
        UpdateGround(newGround);
    }

    public void UpgradeTurret()
    {
        // destroy turret, upgrade the turret, 

        if (!checkUpgradeMoney())
            return;

        Currency.Money -= selectedTurret.upgradeCost;
        DestroyTurret();
        buildManager.SetTurretToBuild(selectedTurret.nextLevel);
        buildManager.BuildTurretOn(selectedGround);
        selectedGround.SetBuildedTurret(selectedTurret.nextLevel);
        buildManager.SetTurretToBuild(null);
        buildManager.ShowInfo(selectedGround);
    }

    public void SellTurret()
    {
        // give turret sell money, destroy the turret
        Currency.Money += selectedGround.GetBuildedTurret().sellValue;
        uiPanel.ClosePanel();
        DestroyTurret();
    }

    private void DestroyTurret()
    {
        selectedGround.destroyCurrentTurret();
    }


    private bool checkUpgradeMoney()
    {
        if (Currency.Money < selectedTurret.upgradeCost)
            return false;
                
        return true;
    }
}
