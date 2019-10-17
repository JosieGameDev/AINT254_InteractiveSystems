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
        if (timerIsActive)
        {
            timeLeft -= Time.deltaTime;
            //Debug.Log(timeLeft);
            if (timeLeft <= 0)
            {
                //gameover

            }

            //update text label
            timerLabel.text = timeLeft.ToString();
        }
        else if(!timerIsActive)
        {
            timerLabel.color = (Color.red);
        }
    }
}
