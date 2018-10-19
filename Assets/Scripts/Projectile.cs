using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]

public class Projectile : MonoBehaviour {

    public AudioClip bounce;
    public AudioClip blockHit;
    public AudioClip playerHit;
    AudioSource audioSource;

    //public bool score;
    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Environment")
        {
            audioSource.PlayOneShot(bounce);
        }
        if (collision.collider.tag == "Block")
        {
            audioSource.PlayOneShot(blockHit);
        }
        if (collision.collider.tag == "Player")
        {
            audioSource.PlayOneShot(playerHit);
        }
    }

    /*void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Block")
        {
            score = true;
        }
    }*/

}
