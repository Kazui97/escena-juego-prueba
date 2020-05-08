using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparo : MonoBehaviour
{
    // Start is called before the first frame update
   public GameObject ranura ;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            
            transform.parent=null;
            GetComponent<Rigidbody>().AddForce(transform.forward*1500);
            //gameObject.AddComponent<Rigidbody>().mass = 5;
            GetComponent<Rigidbody>().useGravity = true;

        }
    }
  
}
