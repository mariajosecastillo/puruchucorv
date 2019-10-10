using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionStore : MonoBehaviour
{
    public bool Joystick;
    public DataPlayer Usuario;
    public Answer Answer;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void SetLogin(string Phone, string Password)
    {
        Usuario = new DataPlayer() { Phone = Phone, Password = Password };
    }

    public void SetAnswer (Answer answer)
    {
        Answer = answer;
    }
}
