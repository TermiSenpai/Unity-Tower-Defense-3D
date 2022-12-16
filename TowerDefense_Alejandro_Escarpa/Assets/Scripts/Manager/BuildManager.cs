using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    [SerializeField] private Turret turretToBuild;
    [SerializeField] private Transform turretParent;

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
        Instantiate(turretToBuild.prefab, ground.GetBuildPos(), Quaternion.identity, turretParent);
        ground.SetBuildedTurret(turretToBuild);


    }

    public void SelectGround(GroundSelector ground)
    {
        Debug.Log(ground.GetBuildedTurret());
    }


    public bool CanBuild { get { return turretToBuild != null; } }

    public void SetTurretToBuild(Turret turret)
    {
        if (Currency.Money < turret.cost)
        {
            Debug.Log("Not enought money to buy");
            return;
        }        
        turretToBuild = turret;

    }

}
