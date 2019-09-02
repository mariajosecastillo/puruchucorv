using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class GUI_Controller : MonoBehaviour
{
    public GameObject[] GUI;

    void Start()
    {
        ReturnMain();
    }
    public void StartVR()
    {
        GUI[0].SetActive(false);
        GUI[1].SetActive(false);
        GUI[2].SetActive(true);
    }

    public void ShowMap()
    {
        GUI[0].SetActive(false);
        GUI[1].SetActive(true);
        GUI[2].SetActive(false);
    }

    public void ReturnMain()
    {
        GUI[0].SetActive(true);
        GUI[1].SetActive(false);
        GUI[2].SetActive(false);
    }

    public void JoyStick(bool have)
    {
        Debug.Log(have);
        SceneManager.LoadScene(1);
    }
}
