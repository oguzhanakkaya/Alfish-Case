using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private Vector3 offset;
    public GameObject clamp;
    void Start()
    {
        offset=new Vector3(0,17.6f,-6.8f);
    }

    
    void Update()
    {
        transform.position = clamp.transform.position + offset;
    }
}
