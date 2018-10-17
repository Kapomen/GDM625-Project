using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellManager : MonoBehaviour {

    //private bool isPlayer1;
    public GameObject thisball;
    public GameObject allyWall;
    public GameObject enemyFloor;
    IceFloorGenerator iceGenerator;
    WallGenerator wallGenerator;
    Ball changeBall;

	// Use this for initialization
	void Start () {
        iceGenerator = enemyFloor.GetComponent<IceFloorGenerator>();
        wallGenerator = allyWall.GetComponent<WallGenerator>();
        changeBall = thisball.GetComponent<Ball>();
    }
	
	// Update is called once per frame
	void Update () {
	}

    public void IgniteBall()
    {
        changeBall.changeFireball();
    }

    public void FortifyWall ()
    {
        //print("FORTIFY WALL");
        wallGenerator.StartCoroutine(wallGenerator.CreateRow());
    }

    public void FreezeFloor ()
    {
        iceGenerator.SpawnIceFloor();
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //}
} //end SpellManager
