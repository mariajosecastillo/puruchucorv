using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR;

public class GUI_Controller : MonoBehaviour
{
    public GameObject[] GUI;
    public GameObject[] GUILogin;
    public GameObject Content;

    public InputField LIPhone;
    public InputField LIPass;
    public InputField SUPhone;
    public InputField SUPass;

    private GameObject SessionStore;
    void Start()
    {
        SessionStore = GameObject.FindGameObjectWithTag("SessionStore");
        //ReturnMain();
    }
    #region Main
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

    #endregion

    #region Login
    public async void Login()
    {
        var ApiController = new ApiController();
        var dp = new DataPlayer() { Phone = LIPhone.text, Password = LIPass.text };

        var response = await ApiController.LogIn(dp);

        if (!string.IsNullOrWhiteSpace(response.Phone))
        {
            SessionStore.GetComponent<SessionStore>().SetLogin(LIPhone.text, LIPass.text);
            GUILogin[0].SetActive(false);
            GUILogin[1].SetActive(false);
            ReturnMain();
        }
        Debug.Log(response);
    }
    public async void Signup()
    {
        var ApiController = new ApiController();
        var dp = new DataPlayer() { Phone = SUPhone.text, Password = SUPass.text };

        var response = await ApiController.SignUp(dp);

        if (response == "true")
        {
            SessionStore.GetComponent<SessionStore>().SetLogin(LIPhone.text, LIPass.text);
            GUILogin[0].SetActive(false);
            GUILogin[1].SetActive(false);
            ReturnMain();
        }
        Debug.Log(response);
    }
    public void ToSignup()
    {
        GUILogin[0].SetActive(false);
        GUILogin[1].SetActive(true);
        RestartContent();
    }
    private void RestartContent()
    {
        Content.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
    }
    #endregion

    public void JoyStick(bool have)
    {
        SessionStore.GetComponent<SessionStore>().Joystick = have;
        SceneManager.LoadScene(1);
    }
}
