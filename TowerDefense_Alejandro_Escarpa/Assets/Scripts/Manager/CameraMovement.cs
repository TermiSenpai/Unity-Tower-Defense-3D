using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private bool canMove = true;

    [Header("Padding")]
    [SerializeField] private float panSpeed;

    [Header("Scrollinig")]
    [SerializeField] private float multiplier;
    [SerializeField] private float scrollSpeed;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            canMove = !canMove;

        if (!canMove)
            return;

        InputCamera();
        ScrollCamera();
    }

    private void InputCamera()
    {
        if (Input.GetKey(KeyCode.W))
            moveCamera(Vector3.forward);
        if (Input.GetKey(KeyCode.S))
            moveCamera(Vector3.back);
        if (Input.GetKey(KeyCode.D))
            moveCamera(Vector3.right);
        if (Input.GetKey(KeyCode.A))
            moveCamera(Vector3.left);
    }

    private void ScrollCamera()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;
        pos.y -= scroll * multiplier * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;
    }

    private void moveCamera(Vector3 dir)
    {
        transform.Translate(dir * panSpeed * Time.deltaTime, Space.World);
    }
}
