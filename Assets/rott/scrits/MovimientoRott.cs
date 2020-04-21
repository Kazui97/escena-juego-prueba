using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoRott : MonoBehaviour
{

    private Animator Animaciones;
    public float Velocidad;
    public float Rotacion;
    public float x, y;


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

        transform.Translate(x * Rotacion * Time.deltaTime,0, 0);
        transform.Translate(0, 0, y * Velocidad * Time.deltaTime);

        Animaciones.SetFloat("VelX", x);
        Animaciones.SetFloat("VelY", y);
    }
}
