using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    [SerializeField] private Turret turretToBuild;
    [SerializeField] private Transform turretParent;
    private GroundSelector selectedGround;
    [SerializeField] ShowTurretInfo turretInfo;
    public GameObject buildedTurret;

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
                turretToBuild = null;

    }


    public void BuildTurretOn(GroundSelector ground)
    {
        if (Currency.Money < turretToBuild.cost)
        {
            Debug.Log("Not enought money to build");
            turretToBuild = null;
            return;
        }
        Currency.Money -= turretToBuild.cost;
        ground.buildedTurret = Instantiate(turretToBuild.prefab, ground.GetBuildPos(), Quaternion.identity, turretParent);
        ground.SetBuildedTurret(turretToBuild);
    }


    public void SelectGround(GroundSelector ground)
    {
        selectedGround = ground;
        if (selectedGround.GetBuildedTurret() == null) return;
        turretInfo.ShowInfo(ground.GetBuildedTurret());

        UpgradeManager.instance.UpdateReferences(ground, ground.GetBuildedTurret().nextLevel);
    }


    public bool CanBuild { get { return turretToBuild != null; } }

    public void SetTurretToBuild(Turret turret)
    {
        if (turret == null)
        {
            turretToBuild = null;
            return;
        }
        if (Currency.Money < turret.cost)
        {
            Debug.Log("Not enought money to buy");
            return;
        }
        turretToBuild = turret;

    }

}
