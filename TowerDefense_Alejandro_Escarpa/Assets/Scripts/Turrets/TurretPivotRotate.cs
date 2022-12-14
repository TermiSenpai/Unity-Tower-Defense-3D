using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPivotRotate : MonoBehaviour
{
    private TargetSearching targetSearching;
    [SerializeField] private Transform partToRotate;
    [SerializeField] private float rotateTime;

    private void Start()
    {
        targetSearching = GetComponent<TargetSearching>();
    }

    private void Update()
    {
        if (targetSearching.GetTarget() == null)
            return;
        ChangeRotateDir();
    }

    private void ChangeRotateDir()
    {
        Vector3 dir = targetSearching.GetTarget().position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * rotateTime).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }
}
