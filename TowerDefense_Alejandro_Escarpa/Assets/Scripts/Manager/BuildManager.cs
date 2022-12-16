using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    [SerializeField] private GameObject turretToBuild;
    private int turretCost;
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
        if (Currency.Money < turretCost)
        {
            Debug.Log("Not enought money to build");
            turretToBuild = null;
            return;
        }
        Currency.Money -= turretCost;
        GameObject turret = Instantiate(turretToBuild, ground.GetBuildPos(), Quaternion.identity, turretParent);
        ground.SetBuildedTurret(turret);


    }


    public bool CanBuild { get { return turretToBuild != null; } }

    public void SetTurretToBuild(Turret turret)
    {
        if (Currency.Money < turret.cost)
        {
            Debug.Log("Not enought money to buy");
            return;
        }
        turretCost = turret.cost;
        turretToBuild = turret.prefab;

    }

}
