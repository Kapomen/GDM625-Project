using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    private bool isPlayer1Block;

	// Use this for initialization
	void Start () {
        CheckPlayer();
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void CheckPlayer()
    {
        WallGenerator wallGenScript = transform.parent.GetComponent<WallGenerator>();
        isPlayer1Block = wallGenScript.Player1Wall;
        //print(isPlayer1Block);
    } //end CheckPlayer

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player") {
            //print("block-player collision");

            //check for PlayerIsAttacking = true
            //Destroy(this.gameObject);
        }
        if (col.gameObject.tag == "Ball")
        {
            print("block-ball collision");
            
            Destroy(this.gameObject);
            GameManager.Instance.BlockDestroyed(isPlayer1Block);
        }
    } //end OnCollisionEnter
} //end Block class
