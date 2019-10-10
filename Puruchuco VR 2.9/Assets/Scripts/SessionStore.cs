using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionStore : MonoBehaviour
{
    public bool Joystick;
    private DataPlayer Usuario;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void SetLogin(string Phone, string Password)
    {
        Usuario = new DataPlayer() { Phone = Phone, Password = Password };
    }
}
