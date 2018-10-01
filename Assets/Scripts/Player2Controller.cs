using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour {

    private bool PlayerIsAttacking;
    private bool PlayerIsDashing;

    public float moveSpeed = 5f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveSpeed * Input.GetAxis("Horizontal2") * Time.deltaTime, 0f, moveSpeed * Input.GetAxis("Vertical2") * Time.deltaTime);

        if (Input.GetKey(KeyCode.M))
        {
            DoAttack();
        }
        else if (Input.GetKey(KeyCode.N))
        {
            DoDash();
        }
        else
        {
            DoNothing();
        }
    }

    void DoAttack()
    {
        if (PlayerIsAttacking == false) { PlayerIsAttacking = true; }
        gameObject.GetComponent<Renderer>().material.color = Color.green;
    } //end DoAttack

    void DoDash() {
        print("Dashing");
    } //end DoSah

    void DoNothing() {
        if (PlayerIsAttacking == true) { PlayerIsAttacking = false; }
        gameObject.GetComponent<Renderer>().material.color = Color.red;
    } //end DoNothing
}
