using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCounting : MonoBehaviour
{

    public Text timerText;

    public float startTime;


    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;
       
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

        startTime -= Time.deltaTime;


        string minutes = Mathf.Floor(startTime / 60).ToString("00");
        string seconds = Mathf.Floor(startTime % 60).ToString("00");

        timerText.text = minutes + ":" + seconds;
    }
}
