using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeLeft = 30f;
    public Text timerLabel;
    public bool timerIsActive = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(timerIsActive);
        if (timerIsActive == true)
        {
            timeLeft -= Time.deltaTime;
            //Debug.Log(timeLeft);
            if (timeLeft <= 0)
            {
                setTimerBool(false);
                timeLeft = 0.0000f;

            }

            //update text label
            timerLabel.text = timeLeft.ToString();
        }
        else if(timerIsActive == false)
        {
            timerLabel.color = (Color.red);
        }
    }

    public void setTimerBool(bool input)
    {
        timerIsActive = input;
    }
}
