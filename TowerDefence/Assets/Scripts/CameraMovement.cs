using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Camera cam;
    private float zoomSpeed = 2f;
    private float moveSpeed = 5f;

    // Limits of movements
    private float zoomMin = 2.5f;   
    private float zoomMax = 6f;
    private int YMin = -3;
    private int YMax = 3;
    private int XMin = -3;
    private int XMax = 3;

    void Start()
    {
        cam = Camera.main;
    }
    void Update()
    {
        Movement();
        Zoom();
    }
    void Zoom()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            cam.orthographicSize -= zoomSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.E))
        {
            cam.orthographicSize += zoomSpeed * Time.deltaTime;
        }

        // Clamp the zoom level
        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, zoomMin, zoomMax);
    }
    void Movement()
    {
        // Get horizontal and vertical input (arrow keys, WASD, or joystick)
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float moveY = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        // Move camera based on input
        Vector3 newPosition = transform.position + new Vector3(moveX, moveY, 0);

        // Clamp the position to stay within boundaries
        newPosition.x = Mathf.Clamp(newPosition.x, XMin, XMax);
        newPosition.y = Mathf.Clamp(newPosition.y, YMin, YMax);

        transform.position = newPosition;
    }
}
