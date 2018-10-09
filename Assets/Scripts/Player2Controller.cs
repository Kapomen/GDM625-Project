using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{

    Animator animator;
    Vector3 defaultScale;

    //private bool PlayerIsAttacking;
    //private bool PlayerIsDashing;

    float stateStartTime;

    float timeInState
    {
        get { return Time.time - stateStartTime; }
    }

    const string M_IdleAnim = "Idle";
    const string M_WalkLeftAnim = "WalkLeft";
    const string M_WalkRightAnim = "WalkRight";
    const string M_WalkVertAnim = "WalkVert";
    const string M_DashLeftAnim = "DashLeft";
    const string M_DashRightAnim = "DashRight";
    const string M_DashVertAnim = "DashVert";
    const string M_AttackAnim = "Attack";
    const string M_EnterDefeatAnim = "EnterDefeat";
    const string M_DefeatAnim = "Defeat";
    const string M_EnterVictoryAnim = "EnterVictory";
    const string M_VictoryAnim = "Victory";

    enum State
    {
        Idle,
        WalkLeft,
        WalkRight,
        WalkVert,
        DashLeft,
        DashRight,
        DashVert,
        Attack,
        EnterDefeat,
        Defeat,
        EnterVictory,
        Victory
    }
    State state;
    float horzInput;
    float vertInput;
    bool attackIsPressed;
    bool dashIsPressed;

    public GameObject ball;
    public GameObject direction;
    private float ballDistance;

    public float moveSpeed = 6f;
    public bool iscooldown1;
    public float dashtimer1 = 0;
    public float dashcooldown = 3f;

    //private Animator animator;


    // Use this for initialization
    void Start()
    {
        //PlayerIsAttacking = false;
        animator = GetComponentInChildren<Animator>();
        defaultScale = transform.localScale;
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
                moveSpeed = 6;
            }
            if (dashtimer1 >= dashcooldown)
            {
                iscooldown1 = false;
                dashtimer1 = 0;
            }
        }

        ballDistance = Vector3.Distance(ball.transform.position, transform.position);

        if (ifstartscounting.battlestarts && !GameManager.Instance.winnerSet)
        {
            horzInput = Input.GetAxisRaw("Horizontal2");
            vertInput = Input.GetAxisRaw("Vertical2");
            attackIsPressed = Input.GetKeyDown(KeyCode.M);
            dashIsPressed = Input.GetKeyDown(KeyCode.N);

            //transform.Translate(moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
            transform.Translate(moveSpeed * horzInput * Time.deltaTime, 0f, moveSpeed * vertInput * Time.deltaTime);

            if (dashIsPressed && !iscooldown1)
            {
                Dash();
            }
            else if (attackIsPressed)
            {
                Attack();
                //gameObject.GetComponent<Renderer>().material.color = Color.green;
                //if (dis <= 3 & dis >= 0)
                //{
                //    Attack();
                //}
            }
            else
            {
                //if (!Walk()) DoNothing();
            }

            ContinueState();
        }

    } //end Update

    void SetOrKeepState(State state)
    {
        if (this.state == state) return;
        EnterState(state);
    } //end SetOrKeepState

    void ExitState() { } //end ExitState

    void EnterState(State state)
    {
        print(state);
        ExitState();
        switch (state)
        {
            case State.Idle:
                animator.Play(M_IdleAnim);
                break;
            case State.Attack:
                animator.Play(M_AttackAnim);
                break;
            case State.WalkLeft:
                animator.Play(M_WalkLeftAnim);
                Face(1);
                break;
            case State.WalkRight:
                animator.Play(M_WalkRightAnim);
                Face(-1);
                break;
            case State.WalkVert:
                animator.Play(M_WalkVertAnim);
                break;
            case State.DashLeft:
                animator.Play(M_DashLeftAnim);
                Face(1);
                break;
            case State.DashRight:
                animator.Play(M_DashRightAnim);
                Face(-1);
                break;
            case State.DashVert:
                animator.Play(M_DashVertAnim);
                break;
            case State.EnterDefeat:
                animator.Play(M_EnterDefeatAnim);
                break;
            case State.EnterVictory:
                animator.Play(M_EnterVictoryAnim);
                break;
        } //end switch

        this.state = state;
        stateStartTime = Time.time;
    } //end EnterState

    void ContinueState()
    {
        switch (state)
        {
            case State.Idle:
                Walk();
                break;

            case State.Attack:
                //if (!Walk()) EnterState(State.Idle);
                if (!Walk()) SetOrKeepState(State.Idle);
                break;

            case State.WalkLeft:
            case State.WalkRight:
            case State.WalkVert:
                if (!Walk()) EnterState(State.Idle);
                break;

            case State.DashLeft:
            case State.DashRight:
            case State.DashVert:
                if (!Dash()) EnterState(State.Idle);
                break;
        } //emd switch
    } //end ContinueState

    void Face(int direction)
    {
        transform.localScale = new Vector3(defaultScale.x * direction, defaultScale.y, defaultScale.z);
    }

    bool Walk()
    {
        //if (horzInput < 0 && vertInput > 0) SetOrKeepState(State.WalkLeft);
        if (vertInput < 0 || vertInput > 0) SetOrKeepState(State.WalkVert);
        else if (horzInput < 0) SetOrKeepState(State.WalkLeft);
        else if (horzInput > 0) SetOrKeepState(State.WalkRight);
        else return false;
        return true;
    } //end Walk


    private void Attack()
    {
        EnterState(State.Attack);
        float power = GetPower();
        if (ballDistance <= 3 & ballDistance >= 0)
        {
            Rigidbody rb = ball.GetComponent<Rigidbody>();
            rb.velocity = GetReflected() * power;
        }


        //ContinueState();
    } //end Attack

    private bool Dash()
    {
        //if (Input.GetKey(KeyCode.D))
        //{
        //    moveSpeed = 20;
        //    iscooldown1 = true;

        //}
        //else if (Input.GetKey(KeyCode.A))
        //{
        //    moveSpeed = 20;
        //    iscooldown1 = true;
        //}

        moveSpeed = 12;
        iscooldown1 = true;

        if (horzInput < 0) SetOrKeepState(State.DashLeft);
        else if (horzInput > 0) SetOrKeepState(State.DashRight);
        else return false;
        return true;
    } //end Dash

    void DoNothing()
    {
        EnterState(State.Idle);
        //SetOrKeepState(State.Idle);
        //gameObject.GetComponent<Renderer>().material.color = Color.red;
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
                rb.velocity = GetReflected() * (power * 0.8f);
            }
        }

    }
}//end Player2Controller class