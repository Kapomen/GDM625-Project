using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
  
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            transform.position = collision.gameObject.transform.position + new Vector3(0, 2, 0);
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        
    }
    
}
