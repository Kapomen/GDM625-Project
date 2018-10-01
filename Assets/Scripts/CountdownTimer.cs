using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour {

    public int timeLeft = 3;
    public Text countdownText;
    public bool battlestarts = false;
    public float intervals = 0;

    // Use this for initialization
    void Start()
    {
        StartCoroutine("LoseTime");
    }

    // Update is called once per frame
    void Update()
    {
        countdownText.text = timeLeft.ToString();

        if (timeLeft <= 0)
        {
            StopCoroutine("LoseTime");
            countdownText.text = "GO!";
            battlestarts = true;
        }

        if(countdownText.text == "GO!")
        {
            intervals += Time.deltaTime;
            if(intervals >= 1f)
            {
                countdownText.text = "";
                intervals = 1;
            }
        }
    }

    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
    }
}
