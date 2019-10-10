using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GUI_Quest : MonoBehaviour
{
    public Answer Answer;
    public GameObject[] GUI;

    public GameObject Content;

    public InputField LIPhone;
    public InputField LIPass;
    public InputField SUPhone;
    public InputField SUPass;

    private GameObject SessionStore;

    public GameObject Award;
    void Start()
    {
        SessionStore = GameObject.FindGameObjectWithTag("SessionStore");
        Answer = new Answer();
    }

    public void AnswerAQuestions(bool ans)
    {
        if (ans)
        {
            GUI[0].SetActive(false);
            GUI[3].SetActive(true);
        }
        else
        {
            foreach (var gui in GUI)
                gui.SetActive(false);

            GUI[GUI.Length - 1].SetActive(true);
        }
    }
    
    public void SeeAwards()
    {
        GUI[3].SetActive(false);
        GUI[4].SetActive(true);
        var award = (Answer.Q1.Equals("A") & Answer.Q2.Equals("B") & Answer.Q3.Equals("B") & Answer.Q4.Equals("B") & Answer.Q5.Equals("A")) ? true : false;
        Award.SetActive(award);
        RestartContent();
    }
    public void SeeQuest()
    {
        GUI[3].SetActive(false);
        GUI[5].SetActive(true);
        RestartContent();
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
    public void BackMain()
    {
        GUI[3].SetActive(true);
        GUI[4].SetActive(false);
        RestartContent();
    }
    private void RestartContent()
    {
        Content.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
    }


    private int i;
    public void PutQuestI (int index)
    {
        i = index;
    }

    public async void PutQuestA(string q)
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

        if (i == 5)
        {
            GUI[GUI.Length - 2].SetActive(true);
            if (await AnswerPut())
                return;
        }
    }

    private async Task<bool> AnswerPut()
    {
        var ApiController = new ApiController();

        Answer.Phone = SessionStore.GetComponent<SessionStore>().Usuario.Phone;
        Answer.Date = DateTime.Now.ToString();

        //var response = await ApiController.AnswerPut(Answer);
        //Debug.Log(response);
        var response = "true";
        if (!string.IsNullOrWhiteSpace(response) && response == "true")
        {
            SessionStore.GetComponent<SessionStore>().SetAnswer(Answer);
            return true;
        }
        //Debug.Log(response);
        return false;
    }
}
