using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudienceMovement : MonoBehaviour {

    public float delta = 0.1f;  // Amount to move left and right from the start point
    public float speed = 10f;
    private Vector3 startPos;
    public bool leftright;
    public bool updown;


    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        //GameObject checkifscore = GameObject.Find("Ball");

        //Projectile isscore = checkifscore.GetComponent<Projectile>();
        
        if (leftright) //&& isscore.score)
        {
            leftandright();
            updown = false;
        }
        if (updown)// && isscore.score)
        {
            
            upanddown();
            leftright = false;
        }
    }

    void leftandright()
    {
        Vector3 v = startPos;
        v.x += delta * Mathf.Sin(Time.time * speed);
        transform.position = v;
    }

    void upanddown()
    {
        Vector3 v = startPos;
        v.y += delta * Mathf.Sin(Time.time * speed);
        transform.position = v;
    }
}
