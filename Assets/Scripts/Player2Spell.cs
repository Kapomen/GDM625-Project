using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Spell : MonoBehaviour {

    public int water;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject icefloorp1 = GameObject.Find("IceFloorSpawnArea (P1)");

        IceFloorGenerator player2spawn = icefloorp1.GetComponent<IceFloorGenerator>();

        if (water == 2)
        {
            player2spawn.SpawnIceFloor();
            water = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Element_Water")
        {
            water++;
        }
    }
}
