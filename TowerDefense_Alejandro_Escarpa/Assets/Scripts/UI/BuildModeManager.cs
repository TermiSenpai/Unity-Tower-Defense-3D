using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildModeManager : MonoBehaviour
{
    BuildManager buildManager;
    [SerializeField] GameObject buildsystem;
    [SerializeField] Image turretImage;
    

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void BuildUI(Sprite image)
    {
        ToggleBuildUI(true);
        turretImage.sprite = image;
    }

    public void ToggleBuildUI(bool value)
    {
        buildsystem.SetActive(value);
    }
}
