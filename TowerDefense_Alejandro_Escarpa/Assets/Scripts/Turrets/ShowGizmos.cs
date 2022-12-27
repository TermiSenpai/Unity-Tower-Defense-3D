using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowGizmos : MonoBehaviour
{
    TurretStats turret;

    private void Start()
    {
        turret = GetComponent<TurretStats>();
    }


    private void OnDrawGizmos()
    {
        if (Application.isPlaying)
            Gizmos.DrawWireSphere(transform.position, turret.turret.range);
        else
            Gizmos.DrawWireSphere(transform.position, 6.0f);
    }


}
