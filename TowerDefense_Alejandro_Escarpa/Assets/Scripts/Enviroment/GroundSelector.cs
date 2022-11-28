using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSelector : MonoBehaviour
{
    [SerializeField] private Color hoverColor;
    [SerializeField] private GameObject turret;
    private Transform turretParent;
    public Color starterColor;
    private Renderer rend;

    private void Start()
    {
        turretParent = GameObject.FindGameObjectWithTag("TurretParent").GetComponent<Transform>();
        rend= GetComponent<Renderer>();
        starterColor = rend.material.color;
    }

    private void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("Can´t build there!");
            return;
        }
        
        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + Vector3.up, transform.rotation, turretParent);
    }

    private void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = starterColor;
    }
}
