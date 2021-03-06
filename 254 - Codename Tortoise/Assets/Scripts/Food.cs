﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Food : MonoBehaviour
{

    // vars
    public int startHealth = 5;
    private int health;
    static int healthPercentage = 100;
    private int percentMultiplier;
    public GameObject food;
    public float damageRechargeTime = .5f;
    private TextMeshProUGUI lettuceHealthLabel;
    public GameObject lettuceHealthLableGO;
    public Image gameOverPanel;
    public GameObject TimerGO;
    public GameManager GameManagerGO;
    public float lifetime = 5f;
    float startTime;
    public ParticleSystem eatingDebris;
    public float particleBurstTime;

    //public RechargeBars decoyHealthBar;

    // UI stuff
    public Sprite threeStars;
    public Sprite twoStars;
    public Sprite oneStar;
    public Image UiStars;
    public lettuceHealthUI uiImage;
    public int level;

    private IEnumerator doDamageCoroutine;


    // Start is called before the first frame update
    void Start()
    {
        

        food = this.gameObject;
        health = startHealth;
        startTime = Time.time;
        eatingDebris.Pause();
        
        percentMultiplier = 100/startHealth;

        if (food.name == "LettucePatch")
        {
            lettuceHealthLabel = lettuceHealthLableGO.GetComponent<TextMeshProUGUI>();
            lettuceHealthLabel.text = getHealthPercentage();
            updateStarRating();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //if its decoy food, it dies automatically after time has passed
        if(food.name == "DecoyFood(Clone)")
        {
            if(Time.time - startTime >= lifetime)
            {
                foodDie(food);

            }
        }
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "tortoise")
        {
            
            collision.gameObject.GetComponent<Animator>().SetInteger("TortoiseStateNumber", 2);
            doDamageCoroutine = takeDamage(collision.gameObject);
            StartCoroutine(doDamageCoroutine);
        }

    }



    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "tortoise")
        {
            collision.gameObject.GetComponent<Animator>().SetInteger("TortoiseStateNumber", 1);
            doDamageCoroutine = takeDamage(collision.gameObject);
            StopCoroutine(doDamageCoroutine);
        }
    }

    public string getHealthPercentage()
    {
        //Debug.Log("health= " + health + " percentage mod = " + percentMultiplier);
        healthPercentage = health * percentMultiplier;
        string healthPercentOutput = healthPercentage.ToString() + "%";
        return healthPercentOutput;
    }

    public int getHealthPercentInt()
    {
        healthPercentage = health * percentMultiplier;
        int healthPercentOutput = healthPercentage;
        return healthPercentOutput;
    }

    private void assignDamage(GameObject collidingObject)
    {
        if (collidingObject.GetComponent<Animator>().GetInteger("TortoiseStateNumber") == 2)
        {
            

            health--;
            //Debug.Log(health + collidingObject.name);
            StartCoroutine("particleSystemToggle");

            if (food.name == "LettucePatch")
            {
                lettuceHealthLabel.text = getHealthPercentage();
                uiImage.updateLettuceHealth(getHealthPercentInt());
                updateStarRating();
            }
           
            if (health <= 0)
            {

                foodDie(collidingObject);
            }
            if (food.name == "LettucePatch" && health <= 0)
            {
                TimerGO.GetComponent<Timer>().setTimerBool(false);
                lettuceHealthLabel.text = "No more lettuce left :(";
                uiImage.updateLettuceHealth(0);
                GlobalObject.Instance.timeRemaining = TimerGO.GetComponent<Timer>().timeLeft;
                //GameManagerGO.StartGame();
                GameManagerGO.endScreenLose();
            }
        }
    }

    private IEnumerator takeDamage(GameObject collidingObject)
    {
        
        while(true)
        {
            assignDamage(collidingObject);
            
           yield return new WaitForSeconds(damageRechargeTime);
            
            //else
            //{
            //    StopAllCoroutines();
            //}
        }
        
    }

    public  IEnumerator particleSystemToggle()
    {
        //Debug.Log("Running particle toggle");
        eatingDebris.Play();
        yield return new WaitForSeconds(particleBurstTime);
        eatingDebris.Stop();

        
    }

    private void foodDie(GameObject collidingTortoise)
    {
        // get all the tortoise currenty eating it 
        GameObject[] allTortoise = GameObject.FindGameObjectsWithTag("tortoise");

        foreach(GameObject g in allTortoise)
        {
            //get all currently in eating state
            if (g.GetComponent<Animator>().GetInteger("TortoiseStateNumber") == 2)
            {
                //change state if they were eating this
                if (g.GetComponent<TortoiseStateChange>().foodBeingEaten == this.gameObject)
                {
                    g.GetComponent<Animator>().SetInteger("TortoiseStateNumber", 1);
                }
            }
        }

        Destroy(this.gameObject);

    }
    
    public void updateStarRating()
    {
        if (healthPercentage >= 70)
        {
            UiStars.sprite = threeStars;
        }
        else if (healthPercentage >= 40)
        {
            UiStars.sprite = twoStars;
        }
        else
        {
            UiStars.sprite = oneStar;
        }
        if(level == 1)
        {
            GlobalObject.Instance.levelOneStars = UiStars.sprite;
        }
        else if (level == 2)
        {
            GlobalObject.Instance.levelTwoStars = UiStars.sprite;
        }
        else if (level == 3)
        {
            GlobalObject.Instance.levelThreeStars = UiStars.sprite;
        }
    }
}
