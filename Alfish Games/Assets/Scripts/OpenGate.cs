using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGate : MonoBehaviour
{
    public bool OpenBool;
    void Start()
    {
        GetComponent<OpenGate>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.rotation.z < 0.65f )
        {
            transform.Rotate(0,0,20*Time.deltaTime);
        }
        
        
    }
    
}
