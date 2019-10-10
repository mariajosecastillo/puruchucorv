using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_Sound_Control : MonoBehaviour
{
    public AudioSource audioSource;
    void Start()
    {
        audioSource.Stop();
    }

    void OnTriggerEnter()
    {
        audioSource.Stop();
    }
    void OnTriggerExit()
    {
        audioSource.Stop();
    }
}
