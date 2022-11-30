using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRange : MonoBehaviour
{
    public GameObject range;

    public void ShowTurretRange(bool value)
    {
        range.SetActive(value);
    }
    public void ToggleTurretRange()
    {
        range.SetActive(!range.activeInHierarchy);
    }
}
