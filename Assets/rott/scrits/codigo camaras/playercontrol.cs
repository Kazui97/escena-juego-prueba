using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontrol : MonoBehaviour
{
    public float Horizontalmove;
    public float Verticalmove;
    private Vector3 playerinput;

    public CharacterController Player;

    public float playerspeed;
    private Vector3 moveplayer;
    public float gravedad = 9.8f;
    public float fallvelocity;
    public float jumpforce;


    public Camera maincamara;
    private Vector3 camaraforward;
    private Vector3 camararight;


    public bool isonslob = false;
    private Vector3 hitnormal;
    public float slidevelocity;
    public float slopeforcedown;

    void Start()
    {
        Player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Horizontalmove = Input.GetAxis("Horizontal");
        Verticalmove = Input.GetAxis("Vertical");

        playerinput = new Vector3(Horizontalmove, 0, Verticalmove);
        playerinput = Vector3.ClampMagnitude(playerinput, 1);



        camdirection();

        moveplayer = playerinput.x * camararight + playerinput.z * camaraforward;

        moveplayer = moveplayer * playerspeed;

        Player.transform.LookAt(Player.transform.position + moveplayer);

        setgravedad();


        playerskills();

        Player.Move(moveplayer *  Time.deltaTime);
    }
 
    // funcion para determinar la direccion a la que mira la camara 
    void camdirection()
    {
        camaraforward = maincamara.transform.forward;
        camararight = maincamara.transform.right;

        camaraforward.y = 0;
        camararight.y = 0;

        camaraforward = camaraforward.normalized;
        camararight = camararight.normalized;

    }
    //funcion para habilidades del jugardor
    void playerskills()
    {
        if (Player.isGrounded && Input.GetButtonDown("Jump"))
        {
            fallvelocity = jumpforce;
            moveplayer.y = fallvelocity;
        }
    }
    // funcion de gravedad 
    void setgravedad()
    {


        if (Player.isGrounded)
        {
            fallvelocity = -gravedad * Time.deltaTime;
            moveplayer.y = fallvelocity;
        }
        else
        {
            fallvelocity -= gravedad * Time.deltaTime;
            moveplayer.y = fallvelocity;
        }

        slidesown();
    }

    // aplica deslisamiento en la ranplas mas enpinadas 
    public void  slidesown()
    {
        //verifica que el angulo del player es mayor al establecido si no es asi se desliza
        isonslob = Vector3.Angle(Vector3.up,hitnormal) >= Player.slopeLimit;

        if(isonslob)
        {
            moveplayer.x += ((1f - hitnormal.y) * hitnormal.x) * slidevelocity;
            moveplayer.z += ((1f - hitnormal.y) * hitnormal.z) * slidevelocity;

            moveplayer.y += slopeforcedown;
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        hitnormal = hit.normal;
    }
}
