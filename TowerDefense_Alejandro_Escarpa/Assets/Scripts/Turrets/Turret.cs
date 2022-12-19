using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = ("Turret"), menuName = ("New turret"))]
public class Turret : ScriptableObject
{
    [Header("Info")]
    public string turretName;
    public Sprite turretImg;

    [Header("Stats")]
    public int damage;
    public float range = 6;
    public float fireRate = 1;
    [TextArea] public string attackDescription;
    [Space]

    [Header("Shooting")]
    public GameObject bullet;

    [Space]
    [Header("Currency")]
    public int cost;
    public GameObject prefab;

    [Space]
    [Header("Upgrading")]
    public GameObject nextLevel;

}
