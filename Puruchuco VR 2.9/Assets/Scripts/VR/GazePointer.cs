using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazePointer : MonoBehaviour
{
    public GameObject Player;
    public  float vel, forward, right, delay;
    private bool joysticks = false;
    void FixedUpdate()
    {
        LayerMask layerMask = ~(1 << LayerMask.NameToLayer("Ignore Raycast"));
        vel = Player.GetComponent<PlayerMovement>().vel;
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 3, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log(hit.collider.tag);
            if (hit.transform.tag == "Sound")
            {
                if (!hit.transform.GetComponent<AudioSource>().isPlaying)
                    hit.transform.GetComponent<AudioSource>().Play();
            }
            if (!joysticks)
            {
                if (hit.collider.tag == "up")
                {
                    delay += Time.deltaTime;
                    forward = 1;
                    right = 0;
                }
                if (hit.collider.tag == "down")
                {
                    delay += Time.deltaTime;
                    forward = -1;
                    right = 0;
                }
                if (hit.collider.tag == "right")
                {
                    delay += Time.deltaTime;
                    forward = 0;
                    right = 1;
                }
                if (hit.collider.tag == "left")
                {
                    delay += Time.deltaTime;
                    forward = 0;
                    right = -1;
                }
                if (hit.collider.tag == "Untagged")
                {
                    delay = 0;
                    forward = 0;
                    right = 0;
                }
            }
        }
        else
        {
            delay = 0;
            forward = 0;
            right = 0;
        }
        if(!joysticks)
            movement();
    }

    void movement()
    {
        if (delay > 2)
        {
            Player.GetComponent<Rigidbody>().MovePosition(Player.GetComponent<Transform>().position + Player.GetComponent<Transform>().forward * vel * forward * Time.deltaTime);
        }

        if (delay > 0.5)
        { 
            Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, 30, 0) * right * Time.deltaTime);
            Player.GetComponent<Rigidbody>().MoveRotation(Player.GetComponent<Rigidbody>().rotation * deltaRotation);
        }
    }
}
