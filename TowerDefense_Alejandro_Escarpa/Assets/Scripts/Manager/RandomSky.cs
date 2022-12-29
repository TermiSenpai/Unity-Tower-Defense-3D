using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RandomSky : MonoBehaviour
{
    [SerializeField] private SkySettings[] skySettings;
    private SkySettings selectedSky;


    private void Awake()
    {
        selectedSky = skySettings[Random.Range(0, skySettings.Length)];
    }

    private void Start()
    {
        // Change the render settings
        RenderSettings.skybox = selectedSky.skybox;
        RenderSettings.ambientIntensity = selectedSky.intensity;

        // Change the directional light
        RenderSettings.sun.color = selectedSky.lightColor;
        RenderSettings.sun.intensity = selectedSky.sunIntensity;
        RenderSettings.sun.shadowStrength = selectedSky.shadowStrenght;

        //Lightmapping.lightingSettings = selectedSky.lightingSettings;
    }
}
