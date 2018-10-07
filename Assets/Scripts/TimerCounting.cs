using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCounting : MonoBehaviour
{
    public Text timerText;
    public float startTime;
    private bool timerAtZero;

    public GameObject ball;

    public GameObject resultMenu;

    //public GameObject launchprefab;

    // Use this for initialization
    void Start()
    {
       Time.timeScale = 1;
        ball.GetComponent<Rigidbody>().useGravity = false;
        ball.GetComponent<Ball>().enabled = false;
        //launchprefab.SetActive(false);
        resultMenu.SetActive(false);

        timerAtZero = false;
    } //end Start

    // Update is called once per frame
    void Update()
    {
        if (!timerAtZero) {
            UpdateTimer();
        }
    } //end Update

    void UpdateTimer()
    {
        
        GameObject scenepause = GameObject.Find("SceneManager");
        gamepausechecking ifpaused = scenepause.GetComponent<gamepausechecking>();
        
        GameObject timeup = GameObject.Find("countdownTimer");
        CountdownTimer ifstartscounting = timeup.GetComponent<CountdownTimer>();

        if (ifstartscounting.battlestarts) {
            startTime -= Time.deltaTime;
            ball.GetComponent<Rigidbody>().useGravity = true;
            ball.GetComponent<Ball>().enabled = true;
        }

        if (startTime <= 0) {
            timerAtZero = true;

            timerText.text = "00" + ":" + "00";
            ifpaused.paused = true;

            GameManager.Instance.CompareBlocksDestroyed();

            if (!resultMenu.activeInHierarchy) {
                resultMenu.SetActive(true);
                ifpaused.pausebutton.SetActive(false);
                ifpaused.resetbutton.SetActive(false);
            }
        } else {
            resultMenu.SetActive(false);
        }

        string minutes = Mathf.Floor(startTime / 60).ToString("00");
        string seconds = Mathf.Floor(startTime % 60).ToString("00");

        timerText.text = minutes + ":" + seconds;
    } //end UpdateTimer
} //end TimerCounting class
