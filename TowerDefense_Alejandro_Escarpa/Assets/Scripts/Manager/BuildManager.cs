using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private Turret turretToBuild;
    [SerializeField] private Transform turretParent;
    private GroundSelector selectedGround;
    [SerializeField] ShowTurretInfo turretInfo;
    [HideInInspector]
    public GameObject buildedTurret;
    public GameObject BuildEffect;
    [SerializeField] private BuildModeManager buildUI;

    private void Awake()
    {

        if (instance != null)
        {
            Debug.LogError("More than one buildManager in scene");
        }
        instance = this;
    }


    private void Update()
    {
        // test
        if (CanBuild)
            if (Input.GetMouseButtonDown(1))
            {
                turretToBuild = null;
                CancelBuildUI();                
            }

    }

    public void CancelBuildUI()
    {
        buildUI.ToggleBuildUI(false);
    }

    // Select the ground and build a turret on it
    public void BuildTurretOn(GroundSelector ground)
    {
        GameObject turretEffect = Instantiate(BuildEffect, ground.GetBuildPos(), Quaternion.identity);
        Destroy(turretEffect, 5);

        ground.buildedTurret = Instantiate(turretToBuild.prefab, ground.GetBuildPos(), Quaternion.identity, turretParent);
        ground.SetBuildedTurret(turretToBuild);
        FxSoundsManager.instance.PlayDefaultBuildClip();
    }

    public bool checkMoney()
    {
        if (Currency.Money < turretToBuild.cost)
        {
            Debug.Log("Not enought money to build");
            turretToBuild = null;
            buildUI.ToggleBuildUI(false);
            return false;
        }
        Currency.Money -= turretToBuild.cost;
        return true;
    }


    public void SelectGround(GroundSelector ground)
    {
        selectedGround = ground;
        if (selectedGround.GetBuildedTurret() == null) return;
        ShowInfo(ground);

        UpgradeManager.instance.UpdateReferences(ground, ground.GetBuildedTurret());

    }


    public bool CanBuild { get { return turretToBuild != null; } }

    public void SetTurretToBuild(Turret turret)
    {
        if (turret == null)
        {
            turretToBuild = null;
            return;
        }
        turretToBuild = turret;
        buildUI.BuildUI(turretToBuild.turretImg);
    }

    public void ShowInfo(GroundSelector ground)
    {
        turretInfo.ShowInfo(ground.GetBuildedTurret());
    }


}
