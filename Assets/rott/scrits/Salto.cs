using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salto : MonoBehaviour
{
   public Rigidbody rb_componente;
   public float salto_velocidad;
   public int numero_salto=2;
   public int salto_actual=0;

   public bool tocar_suelo=true;


    void saltar()
    {
        if(Input.GetButtonDown("Jump") &&(tocar_suelo||numero_salto>salto_actual))  
        {
           rb_componente.velocity=new Vector3(0f,salto_velocidad,0f*Time.deltaTime);
           tocar_suelo=false;
           salto_actual++;
        }
    }
    
    
    
    
    void Start()
    {
        rb_componente=GetComponent<Rigidbody>();
    }

   
    void Update()
    {
        saltar();
    }

    
    void OnCollisionEnter(Collision collision)
    {
        tocar_suelo=true;
        salto_actual=0;
    }





}
