using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour {

    private bool PlayerIsAttacking;
    private bool PlayerIsDashing;
    public GameObject ball;
    public GameObject direction;
    public float moveSpeed = 5f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject timeup = GameObject.Find("countdownTimer");

        CountdownTimer ifstartscounting = timeup.GetComponent<CountdownTimer>();

        float dis = Vector3.Distance(ball.transform.position, transform.position);

        if (ifstartscounting.battlestarts)
        {
            transform.Translate(moveSpeed * Input.GetAxis("Horizontal2") * Time.deltaTime, 0f, moveSpeed * Input.GetAxis("Vertical2") * Time.deltaTime);

            if (Input.GetKey(KeyCode.M))
            {
                if (PlayerIsAttacking == false) { PlayerIsAttacking = true; }
                gameObject.GetComponent<Renderer>().material.color = Color.green;
                if (dis <= 3 & dis >= 0)
                {
                    DoAttack();
                }
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
            
    }

    void DoAttack()
    {
        
        float power = GetPower();
        if (power > 0)
        {
            Rigidbody rb = ball.GetComponent<Rigidbody>();
            rb.velocity = GetReflected() * power;
        }
    } //end DoAttack

    void DoDash() {
        print("Dashing");
    } //end DoSah

    void DoNothing() {
        if (PlayerIsAttacking == true) { PlayerIsAttacking = false; }
        gameObject.GetComponent<Renderer>().material.color = Color.blue;
    } //end DoNothing

    private Vector3 GetReflected()
    {
        Vector3 tennisVector = transform.position - ball.transform.position;
        Vector3 planeTangent = Vector3.Cross(tennisVector, direction.transform.forward);
        Vector3 planeNormal = Vector3.Cross(planeTangent, tennisVector);
        Vector3 reflected = Vector3.Reflect(direction.transform.forward, planeNormal);
        return reflected.normalized;
    }

    private float GetPower()
    {
        float idealDistance = 4;
        float maxPower = 12;
        float x = Vector3.Distance(ball.transform.position, transform.position);
        float y = Mathf.Abs(x - idealDistance) / 3 + 1;
        float power = y * maxPower;
        power = Mathf.Clamp(power, 0, maxPower);
        return power;
    }
}
