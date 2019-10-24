using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Food : MonoBehaviour
{

    // vars
    public int startHealth = 5;
    private int health;
    static int healthPercentage = 100;
    private int percentMultiplier;
    public GameObject food;
    public float damageRechargeTime = .5f;
    public Text lettuceHealthLabel;
    public Image gameOverPanel;
    public GameObject TimerGO;
    public GameManager GameManagerGO;
    public float lifetime = 5f;
    float startTime;
   

    private IEnumerator doDamageCoroutine;


    // Start is called before the first frame update
    void Start()
    {
        food = this.gameObject;
        health = startHealth;
        startTime = Time.time;

        
        percentMultiplier = 100/startHealth;

        if (food.name == "LettucePatch")
        {
            //lettuceHealthLabel.text = health.ToString();
            lettuceHealthLabel.text = getHealthPercentage();
        }
    }

    // Update is called once per frame
    void Update()
    {

        //if (health <= 0 && food.name == "LettucePatch")
        //{
        //    GameManagerGO.StartGame();
        //    TimerGO.GetComponent<Timer>().setTimerBool(false);
            
        //    Destroy(this.gameObject);
        //    lettuceHealthLabel.text = "0% : No more lettuce left :(";
            
            

        //}
        //if(health <= 0)
        //{
        //    Destroy(this.gameObject);
        //}

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


    private IEnumerator takeDamage(GameObject collidingObject)
    {
        
        while(true)
        {
            
            health--;
            //Debug.Log(health + collidingObject.name);
            
            
            if (food.name == "LettucePatch")
            {
                //lettuceHealthLabel.text = health.ToString();
                lettuceHealthLabel.text = getHealthPercentage();
            }
            if (health <= 0)
            {
                
                foodDie(collidingObject);
            }
            if(food.name == "LettucePatch" && health <= 0)
            {
                TimerGO.GetComponent<Timer>().setTimerBool(false);
                lettuceHealthLabel.text = "No more lettuce left :(";
                GlobalObject.Instance.timeRemaining = TimerGO.GetComponent<Timer>().timeLeft;
                //GameManagerGO.StartGame();
                GameManagerGO.endScreenLose();
            }
            //Debug.Log(health + collidingObject.name);
            yield return new WaitForSeconds(damageRechargeTime);
        }
        
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
}
