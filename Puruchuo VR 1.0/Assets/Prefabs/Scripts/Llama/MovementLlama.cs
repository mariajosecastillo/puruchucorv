using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementLlama : MonoBehaviour
{

    public float pos = 10f;
    public GameObject CameraObj;
    //MovimientoCarrito script;
    public int forceConst = 5;
    private bool canJump;
    private Rigidbody selfRigidbody;

    public Animator animator;
    byte idle = 0;
    byte walk = 1;
    byte sprint = 2;

    public Animator m_Animator;

    public bool EnCarro = true;
    public GameObject Jugador;
    public GameObject Llama;
    public GameObject CamaraVR;


    public GameObject Cabeza;

    // Use this for initialization
    void Start()
    {
        selfRigidbody = GetComponent<Rigidbody>();
        //script = GetComponent<MovimientoCarrito>();

        animator = GetComponent<Animator>();


        m_Animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) || Input.GetButton("Fire2"))
        {
            EnCarro = false;
            Jugador.SetActive(true);
            Jugador.transform.parent = null;
            CamaraVR.transform.parent = Cabeza.transform;
            this.enabled = false;
            
        }


        //Check if the horizontal buttons (A,D, left and right arrow keys) are being pressed
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            animator.enabled = true;
        }
        else
        {
            animator.enabled = false;
        }
    }

    private void FixedUpdate()
    {
        //GetComponent<Rigidbody>().MovePosition(transform.position + (new Vector3(CameraObj.transform.forward.x, 0f, CameraObj.transform.forward.z) * pos * Input.GetAxis("Vertical") + new Vector3(CameraObj.transform.right.x, 0f, CameraObj.transform.right.z) * pos * Input.GetAxis("Horizontal")) * Time.deltaTime);

        if (canJump)
        {
            canJump = false;
            selfRigidbody.AddForce(0, forceConst, 0, ForceMode.Impulse);
        }

    }
}
