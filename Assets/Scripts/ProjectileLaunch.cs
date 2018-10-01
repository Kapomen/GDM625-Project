using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLaunch : MonoBehaviour {
    public GameObject projectile;
    public int rand;
	// Use this for initialization
	void Start () {
       

        rand = Random.Range(0, 2);

       
    }
	
	// Update is called once per frame
	void Update () {
        GameObject timeup = GameObject.Find("countdownTimer");

        CountdownTimer ifstartscounting = timeup.GetComponent<CountdownTimer>();

        if (ifstartscounting.battlestarts)
        {

            if (rand == 0)
            {
                projectile.GetComponent<Rigidbody>().velocity = new Vector3(-5f, 0, 0);
            }
            else if (rand == 1)
            {
                projectile.GetComponent<Rigidbody>().velocity = new Vector3(5f, 0, 0);
            }
        }
            
    }
}
