﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GUI_Quest : MonoBehaviour
{
    public Answer Answer;
    public User User;
    public GameObject[] GUI;

    public GameObject Content;

    public InputField LIPhone;
    public InputField LIPass;
    public InputField SUPhone;
    public InputField SUPass;

    void Start()
    {
        User = new User();
        Answer = new Answer();
    }

    public void AnswerAQuestions(bool ans)
    {
        if (ans)
        {
            GUI[0].SetActive(false);
            GUI[1].SetActive(true);
        }
        else
        {
            foreach (var gui in GUI)
                gui.SetActive(false);

            GUI[GUI.Length - 1].SetActive(true);
        }
    }

    public void Login()
    {
        User.Phone = LIPhone.text;
        User.Password = LIPass.text;
        ClearFields();
        RestartContent();
        GUI[1].SetActive(false);
        GUI[3].SetActive(true);
    }
    public void Signup()
    {
        User.Phone = SUPhone.text;
        User.Password = SUPass.text;
        ClearFields();
        BackLogin();
    }
    public void BackLogin()
    {
        GUI[1].SetActive(true);
        GUI[2].SetActive(false);
        RestartContent();
    }
    public void ToSignup()
    {
        GUI[1].SetActive(false);
        GUI[2].SetActive(true);
        GUI[3].SetActive(false);
        RestartContent();
    }

    private void RestartContent()
    {
        Content.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
    }
    private void ClearFields()
    {
        SUPhone.text = "";
        LIPass.text = "";
        LIPhone.text = "";
        LIPass.text = "";
    }

    public void SeeAwards()
    {
        GUI[3].SetActive(false);
        GUI[4].SetActive(true);
        RestartContent();
    }
    public void SeeQuest()
    {
        GUI[3].SetActive(false);
        GUI[5].SetActive(true);
        RestartContent();
    }

    public void BackMain()
    {
        GUI[3].SetActive(true);
        GUI[4].SetActive(false);
        RestartContent();
    }


    private int i;
    public void PutQuestI (int index)
    {
        i = index;
    }

    public void PutQuestA(string q)
    {
        switch (i)
        {
            case 1:
                Answer.Q1 = q;
                break;
            case 2:
                Answer.Q2 = q;
                break;
            case 3:
                Answer.Q3 = q;
                break;
            case 4:
                Answer.Q4 = q;
                break;
            case 5:
                Answer.Q5 = q;
                break;
        }
        
        foreach (var gui in GUI)
        {
            if (gui.name == "Quest-" + i)
            {
                gui.SetActive(false);
            }
        }
        foreach (var gui in GUI)
        {
            if (gui.name == "Quest-" + (i + 1))
            {
                gui.SetActive(true);
                return;
            }
        }

        if(i == 5)
            GUI[GUI.Length - 2].SetActive(true);
    }

    public void Thanks()
    {
        SceneManager.LoadScene(0);
    }
    public void ThanksQuest()
    {
        foreach (var gui in GUI)
            gui.SetActive(false);

        GUI[3].SetActive(true);
    }
}