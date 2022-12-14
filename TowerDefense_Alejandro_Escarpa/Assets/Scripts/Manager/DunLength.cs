using DunGen;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DunLength : MonoBehaviour
{
    private DungeonGenerator dungeon;

    private void Awake()
    {
        dungeon.LengthMultiplier = PlayerPrefs.GetFloat("LengthMultiplier", 1);
    }
}
