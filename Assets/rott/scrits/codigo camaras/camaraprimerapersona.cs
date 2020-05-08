using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class camaraprimerapersona : MonoBehaviour
{
    public Camera PrimeraPersona;
    public float Horizontalspeed;
    public float Verticalspeed;
    float h;
    float v;


    public float velocidadmovi;
    private float movimientoHorizonta;
    private float movimientoVertical;

   

    public SpriteRenderer puntomira;


    private void Awake()
    {
        puntomira = gameObject.GetComponentInChildren<SpriteRenderer>();
    }
    void Start()
    {
       
        puntomira.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        h = Horizontalspeed * Input.GetAxis("Mouse X");
        v = Verticalspeed * Input.GetAxis("Mouse Y");

        transform.Rotate(0, h, 0);
        PrimeraPersona.transform.Rotate(-v, 0, 0);

        movimientoHorizonta = Input.GetAxis("Horizontal");
        movimientoVertical = Input.GetAxis("Vertical");

        transform.Translate(movimientoHorizonta * velocidadmovi * Time.deltaTime, 0, 0);
        transform.Translate(0, 0, movimientoVertical * velocidadmovi * Time.deltaTime);



    }

    private void LateUpdate()
    {
        if(Input.GetMouseButton(1))
        {
            puntomira.enabled = true;
        }
        else
        {
            puntomira.enabled = false;
        }
    }
}
