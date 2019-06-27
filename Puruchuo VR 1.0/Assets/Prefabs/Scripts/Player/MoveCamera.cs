using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {

    /*Rigidbody m_Rigidbody;
    Vector3 m_EulerAngleVelocity;

    void Start()
    {
        //Set the axis the Rigidbody rotates in (100 in the y axis)
        m_EulerAngleVelocity = new Vector3(0, 90, 0);

        //Fetch the Rigidbody from the GameObject with this script attached
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    /*void FixedUpdate()
    {
        Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime * Input.GetAxis("Mouse X"));
        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * deltaRotation);
    }*/

    void Update()
    {
#if UNITY_EDITOR
        transform.Rotate(Vector3.up * 90 * Time.deltaTime * Input.GetAxis("Mouse X"));
#endif
        transform.localPosition = new Vector3(0, 0, 0);
    }


   
}
