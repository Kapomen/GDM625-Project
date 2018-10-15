using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Spell : MonoBehaviour {
    public int water;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GameObject icefloorp2 = GameObject.Find("IceFloorSpawnArea (P2)");

        IceFloorGenerator player1spawn = icefloorp2.GetComponent<IceFloorGenerator>();

        if (water == 2)
        {
            player1spawn.SpawnIceFloor();
            water = 0;
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Element_Water")
        {
            water++;
        }
    }
}
