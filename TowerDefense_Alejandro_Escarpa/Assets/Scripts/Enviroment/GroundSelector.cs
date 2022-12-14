using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class GroundSelector : MonoBehaviour
{
    [SerializeField] private Color hoverColor;
    [SerializeField] private GameObject turret;
    private Transform turretParent;
    public Color starterColor;
    private Renderer rend;

    private BuildManager buildManager;

    private void Start()
    {
        turretParent = GameObject.FindGameObjectWithTag("TurretParent").GetComponent<Transform>();
        rend = GetComponent<Renderer>();
        starterColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        GameObject turretToBuild = buildManager.GetTurretToBuild();


        if (turret != null && turretToBuild != null)
        {
            Debug.Log("Can´t build there!");
            return;
        }

        // Show turret range on click
        if (turret != null && turretToBuild == null)
        {
            Debug.Log(turret);
        }


        if (turretToBuild == null) return;

        turret = (GameObject)Instantiate(turretToBuild, transform.position + (Vector3.up * transform.localScale.x), transform.rotation, turretParent);
        //buildManager.SetTurretToBuild(null);



    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        if (buildManager.GetTurretToBuild() == null) return;

        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = starterColor;
    }
}
