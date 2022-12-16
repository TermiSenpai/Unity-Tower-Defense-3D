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
    
    public Color starterColor;
    private Renderer rend;

    private BuildManager buildManager;


    private void Start()
    {
       
        rend = GetComponent<Renderer>();
        starterColor = rend.material.color;
        buildManager = BuildManager.instance;
    }


    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        if (!buildManager.CanBuild) return;

        if (turret != null)
        {
            Debug.Log("Can�t build there!");
            return;
        }

        buildManager.BuildTurretOn(this);
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        if (!buildManager.CanBuild) return;

        SetBlockColor(hoverColor);
    }

    private void OnMouseExit()
    {
        SetBlockColor(starterColor);
    }

    private void SetBlockColor(Color newColor)
    {
        rend.material.color = newColor;
    }

    public Vector3 GetBuildPos()
    {
        return transform.position + (Vector3.up * transform.localScale.x);
    }

    public void SetBuildedTurret(GameObject newTurret)
    {
        turret = newTurret;
    }
}
