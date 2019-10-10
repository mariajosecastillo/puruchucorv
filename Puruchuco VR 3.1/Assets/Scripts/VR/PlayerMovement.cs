using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float vel = 50f;
    public bool joysticks = false;

    void Start()
    {
        joysticks = GameObject.FindGameObjectWithTag("SessionStore") != null ? GameObject.FindGameObjectWithTag("SessionStore").GetComponent<SessionStore>().Joystick : false;
    }

    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) // Sonido de Pasos.
        {
            if (!GetComponent<AudioSource>().isPlaying)
            {
                GetComponent<AudioSource>().Play();
            }
        }
        else if (Input.GetAxis("Horizontal") == 0 || Input.GetAxis("Vertical") == 0)
        {
            GetComponent<AudioSource>().Stop();
        }

        if (Input.GetButton("Fire3"))
        {
            vel = 7;
        }
        else
        {
            vel = 3.5f;
        }
    }

    private void FixedUpdate()
    {
        if (!joysticks)
        {
            GetComponent<Rigidbody>().MovePosition(transform.position + transform.forward * vel * Input.GetAxis("Vertical") * Time.deltaTime);

            Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, 90, 0) * Input.GetAxis("Horizontal") * Time.deltaTime);
            GetComponent<Rigidbody>().MoveRotation(GetComponent<Rigidbody>().rotation * deltaRotation);
        }
    }
}
