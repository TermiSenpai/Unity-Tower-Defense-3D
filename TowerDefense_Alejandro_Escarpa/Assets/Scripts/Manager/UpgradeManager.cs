using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager instance;
    [SerializeField] UIPanelsManager uiPanel;

    GroundSelector selectedGround;
    Turret selectedTurret;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one UpgradeManager in scene");
        }
        instance = this;
    }

    public void updateTurret(Turret newTurret)
    {
        selectedTurret = newTurret;
    }


    public void UpdateGround(GroundSelector ground)
    {
        selectedGround = ground;
    }

    public void UpdateReferences(GroundSelector newGround, Turret newTurret)
    {
        updateTurret(newTurret);
        UpdateGround(newGround);
    }

    public void UpgradeTurret()
    {
        selectedGround.destroyCurrentTurret();
        BuildManager.instance.SetTurretToBuild(selectedTurret);
        BuildManager.instance.BuildTurretOn(selectedGround);
        selectedGround.SetBuildedTurret(selectedTurret);
        BuildManager.instance.SetTurretToBuild(null);
    }

    public void SellTurret()
    {
        Currency.Money += selectedGround.GetBuildedTurret().sellValue;
        uiPanel.ClosePanel();
        selectedGround.destroyCurrentTurret();
    }
}
