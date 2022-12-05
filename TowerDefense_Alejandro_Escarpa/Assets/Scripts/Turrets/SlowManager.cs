using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowManager : MonoBehaviour
{
    [SerializeField,Range(0f,1f), Tooltip("minus is more slow")] float slowPercent;

    public float GetSlowPercent() { return slowPercent; }
}
