using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    [SerializeField] private GameObject turretToBuild;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one buildManager in scene");
        }
        instance = this;
    }


    public GameObject GetTurretToBuild() { return turretToBuild; }

    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }

}
