using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_mouse_movement : MonoBehaviour
{
    float speedH = 2;
    float speedV = 2;

    private float yaw = 0;
    private float pitch = 0;

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            yaw += speedH * Input.GetAxis("Mouse X");
            pitch -= speedV * Input.GetAxis("Mouse Y");

            transform.eulerAngles = new Vector3(pitch, yaw, 0);
        }
    }
}
