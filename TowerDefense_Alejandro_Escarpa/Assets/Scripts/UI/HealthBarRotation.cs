using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarRotation : MonoBehaviour
{
    private Camera mainCamera;
    [SerializeField] RectTransform healthbar;
    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        Vector3 direction = mainCamera.transform.position - healthbar.transform.position;
        this.transform.rotation = Quaternion.LookRotation(direction);
    }
}
