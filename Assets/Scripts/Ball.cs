using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public float thrust;
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //start motion
        rb.AddForce(transform.forward * thrust);
    }

    void FixedUpdate()
    {
        //rb.AddForce(transform.forward * thrust);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //rb.AddForce(transform.forward * thrust);
    }
}  //end Ball class
