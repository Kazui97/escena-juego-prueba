using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoRott : MonoBehaviour
{

    private Animator Animaciones;
    public float Velocidad;
    public float Rotacion;
    public float x, y;

    


    float mouseX;
    



    private void Awake()
    {
        Animaciones = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        mouseX += Input.GetAxis("Mouse X");
         

        

        transform.Translate(x * Rotacion * Time.deltaTime,0, 0);
        transform.Translate(0, 0, y * Velocidad * Time.deltaTime);
         //transform.Rotate(0, mouseY*Velocidad * Time.deltaTime,0);
        transform.eulerAngles = new Vector3(0,mouseX, 0);
       
      
      

        Animaciones.SetFloat("VelX", x);
        Animaciones.SetFloat("VelY", y);

        
    }
}
