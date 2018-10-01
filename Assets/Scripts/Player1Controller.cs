using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour {

    private bool PlayerIsAttacking;
    private bool PlayerIsDashing;

    public float moveSpeed = 5f;
    // Use this for initialization
	void Start () {
        PlayerIsAttacking = false;
	}

    // Update is called once per frame
    void Update()
    {
        GameObject timeup = GameObject.Find("countdownTimer");

        CountdownTimer ifstartscounting = timeup.GetComponent<CountdownTimer>();

        if (ifstartscounting.battlestarts)
        {
            transform.Translate(moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);

            if (Input.GetKey(KeyCode.Q))
            {
                DoAttack();
            }
            else if (Input.GetKey(KeyCode.LeftShift))
            {
                DoDash();
            }
            else
            {
                DoNothing();
            }
        }

    } //end Update

    void DoAttack()
    {
        if (PlayerIsAttacking == false) { PlayerIsAttacking = true; }
        gameObject.GetComponent<Renderer>().material.color = Color.green;
    } //end DoAttack

    void DoDash()
    {
        print("Dashing");
    } //end DoSah

    void DoNothing()
    {
        if (PlayerIsAttacking == true) { PlayerIsAttacking = false; }
        gameObject.GetComponent<Renderer>().material.color = Color.red;
    } //end DoNothing
}  //end Player1Controller class
