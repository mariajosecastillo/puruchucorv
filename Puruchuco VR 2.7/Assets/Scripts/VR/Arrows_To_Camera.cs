using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrows_To_Camera : MonoBehaviour
{
    public float smooth = 2.0F;

    public Transform ToCamera;

    private bool MoveArrows = false;
    void Update()
    {
        if (Mathf.Abs(ToCamera.rotation.y) - Mathf.Abs(transform.rotation.y) > 0.125)
            MoveArrows = true;

        if (transform.rotation == ToCamera.rotation)
            MoveArrows = false;

        if (MoveArrows)
            transform.rotation = Quaternion.Slerp(ToCamera.rotation, transform.rotation, Time.deltaTime * smooth);

    }
}
