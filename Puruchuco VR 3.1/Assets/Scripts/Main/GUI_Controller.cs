using System;
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
    public   Text Message;
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
        /*try
        {
            var ApiController = new ApiController();
            var dp = new DataPlayer() { Phone = LIPhone.text, Password = LIPass.text };

            //var response = await ApiController.LogIn(dp);

            var response = dp;
            if (!string.IsNullOrWhiteSpace(response.Phone))
            {
                SessionStore.GetComponent<SessionStore>().SetLogin(LIPhone.text, LIPass.text);
                SessionStore.GetComponent<SessionStore>().SetAnswer(await ApiController.AnswerGet(dp));
                GUILogin[0].SetActive(false);
                GUILogin[1].SetActive(false);
                ReturnMain();
            }
            //Debug.Log(response);
        }
        catch (Exception e)
        {
            Message.text = e.Message;
            StartCoroutine(ShowByTime(3, Message.gameObject));
            Message.text = "";
        }*/
    }
    public async void Signup()
    {
        /*try
        {
            var ApiController = new ApiController();
            var dp = new DataPlayer() { Phone = SUPhone.text, Password = SUPass.text };

            //var response = await ApiController.SignUp(dp);
            var response = "true";
            if (response == "true")
            {
                ToLogin();
                /*SessionStore.GetComponent<SessionStore>().SetLogin(LIPhone.text, LIPass.text);
                GUILogin[0].SetActive(false);
                GUILogin[1].SetActive(false);
                ReturnMain();*
            }
            //Debug.Log(response);
        }
        catch (Exception e)
        {
            Message.text = e.Message;
            StartCoroutine(ShowByTime(3, Message.gameObject));
            Message.text = "";
        }*/
    }
    public void ToLogin()
    {
        GUILogin[1].SetActive(false);
        GUILogin[0].SetActive(true);
        RestartContent();
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

    IEnumerator ShowByTime(int sec, GameObject go)
    {
        go.SetActive(true);
        yield return new WaitForSeconds(sec);
        go.SetActive(false);
    }
}
