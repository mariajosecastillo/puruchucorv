using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountLlama : MonoBehaviour
{

    public GameObject Jugador;
    public GameObject Llama;
    public GameObject CamaraVR;
    public GameObject EmptyGameObject;
    MovementLlama scriptMove;
    public bool estado = false;
    public bool EnCarro;
    void Start()
    {
        Jugador = GameObject.FindWithTag("Player");
        scriptMove = GetComponent<MovementLlama>();
        //mounted = false;
        EnCarro = false;
    }

    void Update()
    {
        if (estado && (Input.GetKeyDown(KeyCode.E)||Input.GetButton("Fire2")))
        {
            EnCarro = true;
            Jugador.SetActive(false);
            //CamaraVR.transform.parent = Llama.transform;
            CamaraVR.transform.parent = EmptyGameObject.transform;
            Jugador.transform.parent = Llama.transform;
            Llama.GetComponent<MovementLlama>().enabled = true;
            scriptMove.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.F)||Input.GetButton("Fire3"))
        {
            EnCarro = false;
            //Jugador.SetActive(true);
            //Jugador.transform.parent;
            //CamaraVR.transform.parent = Jugador.transform;
            //scriptMove.enabled = false;  
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Llamita")
        {
            estado = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Llamita")
        {
            estado = false;
        }
    }
}
