using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRoad : MonoBehaviour
{
    public GameObject clamp;
    public ProgressBar progressBar;
    void Start()
    {
        clamp=GameObject.Find("Clamp");
        progressBar = GameObject.Find("ProgressBar").GetComponent<ProgressBar>();
    }

    // Update is called once per frame
    void Update()
    {
        if (clamp.transform.position.z - transform.position.z > 142f)
        {
            Destroy(this.gameObject);
        }
    }

 
}
