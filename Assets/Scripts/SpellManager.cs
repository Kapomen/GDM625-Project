using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class SpellManager : MonoBehaviour {

    //private bool isPlayer1;
    public GameObject thisball;
    public GameObject allyWall;
    public GameObject enemyFloor;
    IceFloorGenerator iceGenerator;
    WallGenerator wallGenerator;
    Ball changeBall;
    public AudioClip SpellComplete;
    AudioSource audioSource;

    // Use this for initialization
    void Start () {
        iceGenerator = enemyFloor.GetComponent<IceFloorGenerator>();
        wallGenerator = allyWall.GetComponent<WallGenerator>();
        changeBall = thisball.GetComponent<Ball>();
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
	}

    public void IgniteBall()
    {
        changeBall.changeFireball();
        audioSource.PlayOneShot(SpellComplete);
    }

    public void FortifyWall ()
    {
        //print("FORTIFY WALL");
        wallGenerator.StartCoroutine(wallGenerator.CreateRow());
        audioSource.PlayOneShot(SpellComplete);
    }

    public void FreezeFloor ()
    {
        iceGenerator.SpawnIceFloor();
        audioSource.PlayOneShot(SpellComplete);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //}
} //end SpellManager
