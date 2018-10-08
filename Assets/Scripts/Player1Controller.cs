using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour
{

    private bool PlayerIsAttacking;
    private bool PlayerIsDashing;

    public GameObject ball;
    public GameObject direction;

    public float moveSpeed = 10f;
    public bool iscooldown1;
    public float dashtimer1 = 0;
    public float dashcooldown = 3f;

    //private Animator animator;


    // Use this for initialization
    void Start()
    {
        PlayerIsAttacking = false;
        //animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
 
        GameObject timeup = GameObject.Find("countdownTimer");

        CountdownTimer ifstartscounting = timeup.GetComponent<CountdownTimer>();

        if (iscooldown1)
        {
            dashtimer1 += Time.deltaTime;
            if (dashtimer1 >= 1)
            {
                moveSpeed = 10;
            }
            if (dashtimer1 >= dashcooldown)
            {
                iscooldown1 = false;
                dashtimer1 = 0;
            }
        }


        float dis = Vector3.Distance(ball.transform.position, transform.position);


        if (ifstartscounting.battlestarts && !GameManager.Instance.winnerSet)
        {

            transform.Translate(moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);

            if (Input.GetKey(KeyCode.Q))
            {
                if (PlayerIsAttacking == false) { PlayerIsAttacking = true; }
                gameObject.GetComponent<Renderer>().material.color = Color.green;
                if (dis <= 3 & dis >= 0)
                {
                    DoAttack();
                }

            }
            else if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                if (!iscooldown1)
                {
                    DoDash();
                }
            }
            else
            {
                DoNothing();
            }


        }

    } //end Update

    void DoAttack()
    {

        float power = GetPower();
        if (power > 0)
        {
            Rigidbody rb = ball.GetComponent<Rigidbody>();
            rb.velocity = GetReflected() * power;
        }
    } //end DoAttack

    void DoDash()
    {
        if (Input.GetKey(KeyCode.D))
        {
            moveSpeed = 20;
            iscooldown1 = true;

        }
        else if (Input.GetKey(KeyCode.A))
        {
            moveSpeed = 20;
            iscooldown1 = true;
        }

        print("Dashing");
    } //end DoSah

    void DoNothing()
    {
        if (PlayerIsAttacking == true) { PlayerIsAttacking = false; }
        gameObject.GetComponent<Renderer>().material.color = Color.red;
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
        float maxPower = 15;
        float x = Vector3.Distance(ball.transform.position, transform.position);
        float y = Mathf.Abs(x - idealDistance) / 3 + 1;
        float power = y * maxPower;
        power = Mathf.Clamp(power, 0, maxPower);
        return power;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ball")
        {
            float power = GetPower();
            if (power > 0)
            {
                Rigidbody rb = ball.GetComponent<Rigidbody>();
                rb.velocity = GetReflected() * (power*0.8f);
            }
        }

    }
}//end Player1Controller class
