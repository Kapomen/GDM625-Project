﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCounting : MonoBehaviour
{

    public Text timerText;

    public float startTime;

    public GameObject ball;

    //public GameObject launchprefab;

    // Use this for initialization
    void Start()
    {
       Time.timeScale = 1;
        ball.GetComponent<Rigidbody>().useGravity = false;
        ball.GetComponent<Ball>().enabled = false;
        //launchprefab.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
    }

    void UpdateTimer()
    {
        /*
        GameObject scenepause = GameObject.Find("SceneManager");

        gamepausechecking ifpaused = scenepause.GetComponent<gamepausechecking>();
        */

        GameObject timeup = GameObject.Find("countdownTimer");

        CountdownTimer ifstartscounting = timeup.GetComponent<CountdownTimer>();

        if (ifstartscounting.battlestarts)
        {
            startTime -= Time.deltaTime;
            ball.GetComponent<Rigidbody>().useGravity = true;
            ball.GetComponent<Ball>().enabled = true;

        }
       


        string minutes = Mathf.Floor(startTime / 60).ToString("00");
        string seconds = Mathf.Floor(startTime % 60).ToString("00");

        timerText.text = minutes + ":" + seconds;
    }
}
