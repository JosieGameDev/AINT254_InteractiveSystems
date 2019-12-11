using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


public class Timer : MonoBehaviour
{
    
    public double timeLeft = 30f;
    public GameObject timerLabelGO;
    private TextMeshProUGUI timerLabel;
    public bool timerIsActive = true;
    public GameManager GM;
    public Food lettucePatch;
    public bool timerCountsDown = true;
    public float currentTime;
    public float startTime;

    // Start is called before the first frame update
    void Start()
    {
        timerLabel = timerLabelGO.GetComponent<TextMeshProUGUI>();
        if(!timerCountsDown)
        {
            startTime = Time.time;
        }

        GlobalObject.Instance.refOfLevelJustPlayed = GameObject.FindGameObjectWithTag("GameMan").GetComponent<GameManager>().thisLevelRef;
    }

    // Update is called once per frame
    void Update()
    {
        if(timerCountsDown)
        {
            countDownUpdate();
        }
        else if (!timerCountsDown)
        {

        }
            
       
    }

    public void countDownUpdate()
    {
        if (timerIsActive == true)
        {
            timeLeft -= Time.deltaTime;
            //Debug.Log(timeLeft);
            if (timeLeft <= 0)
            {
                setTimerBool(false);
                timeLeft = 0.0000f;
                GlobalObject.Instance.healthLeft = lettucePatch.getHealthPercentInt();
                GM.endScreenWin();
            }

            //update text label
            timeLeft = Math.Round(timeLeft, 2);
            timerLabel.text = timeLeft.ToString();
        }
        else if (timerIsActive == false)
        {
            timerLabel.color = (Color.red);
        }
    }

    public void countUpUpdate()
    {
        if(timerIsActive)
        {
            currentTime = Time.time - startTime;
            timerLabel.text = currentTime.ToString();
        }
    }

    public void setTimerBool(bool input)
    {
        timerIsActive = input;
    }

    public void endGame()
    {
        GM.StartGame();
    }

    
}
