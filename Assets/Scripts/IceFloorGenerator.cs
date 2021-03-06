﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceFloorGenerator : MonoBehaviour {

    public Vector3 center;
    public Vector3 size;
    public GameObject icefloor;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void SpawnIceFloor()
    {
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), 0.4f, Random.Range(-size.z / 2, size.z / 2));
        Instantiate(icefloor, pos, Quaternion.identity);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);
    }
} //end IceFloorGenerator class
