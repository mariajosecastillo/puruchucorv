using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazePointer : MonoBehaviour
{
    void FixedUpdate()
    {
        LayerMask layerMask = ~(1 << LayerMask.NameToLayer("Ignore Raycast"));

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 15, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            if (hit.transform.tag == "Sound")
            {
                if (!hit.transform.GetComponent<AudioSource>().isPlaying)
                    hit.transform.GetComponent<AudioSource>().Play();
            }
        }
    }
}
