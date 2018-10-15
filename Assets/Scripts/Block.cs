using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    private bool isPlayer1Block;

    public float ElementDropRate;

    private GameObject elementSpawner;

    // Use this for initialization
    void Start () {
        CheckPlayer();
        if (isPlayer1Block) {
            elementSpawner = GameObject.Find("SpawnArea (P1)"); 
        } else {
            elementSpawner = GameObject.Find("SpawnArea (P2)");
        }
    } //end Start
	
	// Update is called once per frame
	void Update () {
	}

    private void CheckPlayer()
    {
        WallGenerator wallGenScript = transform.parent.GetComponent<WallGenerator>();
        isPlayer1Block = wallGenScript.Player1Wall;
        //print(isPlayer1Block);
    } //end CheckPlayer

    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Player") {
            //print("block-player collision");

            //check for PlayerIsAttacking = true
            //Destroy(this.gameObject);
        }
        if (col.gameObject.tag == "Ball")
        {
            Destroy(this.gameObject);
            GameManager.Instance.BlockDestroyed(isPlayer1Block);

            float elementDrop = Random.Range(0.0f, 1.0f);
            if(elementDrop <= ElementDropRate)
            {
                ElementGenerator elementGenerator = elementSpawner.GetComponent<ElementGenerator>();
                elementGenerator.SpawnElement();
                print("Element Dropped (" +elementDrop + "%)");
            }
        }
    } //end OnCollisionEnter
} //end Block class
