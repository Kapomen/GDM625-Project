using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour {

    private bool PlayerIsAttacking;

    public float moveSpeed = 5f;
    // Use this for initialization
	void Start () {
        PlayerIsAttacking = false;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(moveSpeed*Input.GetAxis("Horizontal")*Time.deltaTime, 0f, moveSpeed*Input.GetAxis("Vertical")*Time.deltaTime);
        DoAttack();
	}

    void DoAttack()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            if (PlayerIsAttacking == false) { PlayerIsAttacking = true; }
            gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
        else
        {
            if (PlayerIsAttacking == true) { PlayerIsAttacking = false; }
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }

    }
}
