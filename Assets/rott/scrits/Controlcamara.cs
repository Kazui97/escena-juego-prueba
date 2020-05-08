using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlcamara : MonoBehaviour
{      

    public Vector3 offset;

    public Transform target;
    
    void Start()
    {
        target=GameObject.Find("Player").transform;
    }

    
    void LateUpdate()
    {
        
    }
}
