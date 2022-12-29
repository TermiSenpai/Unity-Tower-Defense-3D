using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = ("Sky"), menuName = ("New sky"))]
public class SkySettings : ScriptableObject
{
    [Header("RenderSettings")]
    public Material skybox;
    [Range(0f,1f)] public float intensity;

    [Header("LightSettings")]
    [Range(0.5f,2f)] public float sunIntensity = 0.5f;
    [Range(0f,1f)] public float shadowStrenght;
    public Color lightColor;

    public LightingSettings lightingSettings;
}
