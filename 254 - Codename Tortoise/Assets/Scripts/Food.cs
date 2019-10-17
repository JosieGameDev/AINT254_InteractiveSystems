using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Food : MonoBehaviour
{

    // vars
    public int health = 5;
    public GameObject food;
    public float damageRechargeTime = .5f;
    public Text lettuceHealthLabel;
    public Image gameOverPanel;
    public GameObject Timer;

    private IEnumerator doDamageCoroutine;


    // Start is called before the first frame update
    void Start()
    {
        food = this.gameObject;

        if (food.name == "LettucePatch")
        {
            lettuceHealthLabel.text = health.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (health <= 0)
        {
            Destroy(this.gameObject);
            lettuceHealthLabel.text = "No more lettuce left :(";
            Timer.GetComponent<Timer>().timerIsActive = false;

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





    private IEnumerator takeDamage(GameObject collidingObject)
    {
        
        while(true)
        {
            
            health--;
            //Debug.Log(health + collidingObject.name);
            
            if (food.name == "LettucePatch")
            {
                lettuceHealthLabel.text = health.ToString();
            }
            if (health <= 0)
            {
                foodDie(collidingObject);
            }
            if(food.name == "LettucePatch" && health <= 0)
            {
                lettuceHealthLabel.text = "No more lettuce left :(";
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
