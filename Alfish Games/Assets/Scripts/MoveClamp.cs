using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveClamp : MonoBehaviour
{
    private Touch touch;
    public float movementSpeed = 6.5f;
    private Rigidbody rb;
    public bool MoveBool;
    public GameObject road;
    public ProgressBar progressBar;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        MoveBool = true;
    }
    
    void Update()
    {
       ClampMovement();
    }

    private void ClampMovement()
    {
        if (MoveBool)
        {
           rb.velocity=new Vector3(0,0,movementSpeed);
        }
        else
        {
            rb.velocity=Vector3.zero;
        }
        
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                if (transform.position.x + touch.deltaPosition.x / 15f < 2.3f &&
                    transform.position.x + touch.deltaPosition.x / 15f > -2.3f)
                {
                    rb.velocity+=new Vector3(touch.deltaPosition.x,0,0);
                }
            }
        }
    }
    
    public void OnTriggerEnter(Collider col)
    {
        switch (col.tag)
        {
            case "Finish":
                col.enabled = false;
                progressBar.LevelPass();
                Instantiate(road, new Vector3(0, 1.5f, transform.position.z + 3f), Quaternion.identity);
                StartCoroutine(SetGates());
                break;

            default:
                break;
        }    
    }
    public IEnumerator SetGates()
    {
        yield return new WaitForSeconds(3);
        progressBar.SetObject();
    }
}
