using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    //public float thrust;
    //public Rigidbody rb;
    public Sprite normalballSprite;
    public Sprite fireballSprite; // Drag your first sprite here
    public SpriteRenderer spriteRenderer;
    void Start()
    {
        //rb = GetComponent<Rigidbody>();

        //rb.velocity = new Vector3(thrust, 0, 0);
        //start motion
        //rb.AddForce(transform.forward * thrust);
    }

    void FixedUpdate()
    {
        //rb.AddForce(transform.forward * thrust);
    }

    IEnumerator LateCall()
    {
        yield return new WaitForSeconds(5);
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = rb.velocity / 2;
        spriteRenderer.sprite = normalballSprite;
    }

    public void changeFireball()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = rb.velocity*2;
        //spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = fireballSprite;
        StartCoroutine(LateCall());
    }

    private void OnCollisionEnter(Collision collision)
    {
        //rb.AddForce(transform.forward * thrust);
    }
}  //end Ball class
