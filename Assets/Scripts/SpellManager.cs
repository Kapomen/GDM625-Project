using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellManager : MonoBehaviour {

    //private bool isPlayer1;
    public GameObject floorSpawner;
    IceFloorGenerator iceGenerator;

	// Use this for initialization
	void Start () {
        iceGenerator = floorSpawner.GetComponent<IceFloorGenerator>();
    }
	
	// Update is called once per frame
	void Update () {
	}

    public void FreezeFloor ()
    {
        iceGenerator.SpawnIceFloor();
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //}
} //end SpellManager
