using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceFloor : MonoBehaviour {
    public float delayTimer1 = 2f;
    public float delayTimer2 = 2f;
    public float currenTtimer1;
    public float currenTtimer2;
    public bool Indelay1;
    public bool Indelay2;
    public bool insliding1;
    public bool insliding2;
    public bool player1onice;
    public bool player2onice;
    public float destroytime;

    // Use this for initialization
    void Start () {
        

    }
	
	// Update is called once per frame
	void Update () {
        Destroy(gameObject, destroytime);
        if (Indelay1)
        {
            currenTtimer1 += Time.deltaTime;
            Iceflooractivate1();
            if(currenTtimer1 >= 2f)
            {
                Indelay1 = false;
                currenTtimer1 = 0;
                insliding1 = true;
            }
        }
        //GameObject player1 = GameObject.Find("player1 2D");

        //Player1Controller player1speed = player1.GetComponent<Player1Controller>();

        if (insliding1 && player1onice)
        {
            DoSliding1();
        }

        //GameObject player2 = GameObject.Find("player2 2D");

        //Player2Controller player2speed = player2.GetComponent<Player2Controller>();

        if (Indelay2)
        {
            currenTtimer2 += Time.deltaTime;
            Iceflooractivate2();
            if (currenTtimer2 >= 2f)
            {
                Indelay2 = false;
                currenTtimer2 = 0;
                insliding2 = true;
            }
        }
        if (insliding2 && player2onice)
        {
            DoSliding2();
        }
    }
    void DoSliding1()
    {
        GameObject player1 = GameObject.Find("player1 2D");

        Player1Controller player1speed = player1.GetComponent<Player1Controller>();

        player1.transform.position += transform.right * player1speed.moveSpeed / 2 * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.W)||Input.GetKeyDown(KeyCode.A)||Input.GetKeyDown(KeyCode.S)|| Input.GetKeyDown(KeyCode.D))
        {
            insliding1 = false;
            Indelay1 = false;
        }
    }

    void Iceflooractivate1()
    {
        GameObject player1 = GameObject.Find("player1 2D");

        Player1Controller player1speed = player1.GetComponent<Player1Controller>();

        player1speed.moveSpeed = Mathf.SmoothStep(0, 6f, currenTtimer1 / delayTimer1);

    }

    void DoSliding2()
    {
        GameObject player2 = GameObject.Find("player2 2D");

        Player2Controller player2speed = player2.GetComponent<Player2Controller>();

        player2.transform.position += transform.right * player2speed.moveSpeed / 2 * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            insliding2 = false;
            Indelay2 = false;
        }
    }

    void Iceflooractivate2()
    {
        GameObject player2 = GameObject.Find("player2 2D");

        Player2Controller player2speed = player2.GetComponent<Player2Controller>();

        player2speed.moveSpeed = Mathf.SmoothStep(0, 6f, currenTtimer2 / delayTimer2);

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "player1 2D")
        {
            Indelay1 = true;
            player1onice = true;
        }
        if (other.gameObject.name == "player2 2D")
        {
            Indelay2 = true;
            player2onice = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "player1 2D")
        {
            Indelay1 = false;
            currenTtimer1 = 0;
            player1onice = false;
        }
        if (other.gameObject.name == "player2 2D")
        {
            Indelay2 = false;
            currenTtimer2 = 0;
            player2onice = false;
        }
    }
}
