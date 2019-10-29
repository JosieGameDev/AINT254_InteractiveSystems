using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TortoiseStateChange : MonoBehaviour
{
    // VARIABLES
    public GameObject tortoise;
    public Animator tortoiseAnimator;
    public int previousState;
    public float pauseTime = 3f;
    public GameObject isGoalGO;
    public GameObject foodBeingEaten;
    public GameObject spawnedDecoy;
    public int zAdjustment = 10;
    
    private GameObject player;
    private PlayerActions playerAction;

    public float playerFlipRange = 5;
    // Start is called before the first frame update
    void Start()
    {
        tortoise = this.gameObject;
        tortoiseAnimator = this.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerAction = player.GetComponent<PlayerActions>();
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerAction = player.GetComponent<PlayerActions>();
    }

    private void OnMouseOver()
    {
         // SCRIPT TO FLIP TORTOISE WHEN IT'S CLICKED

        if(Input.GetMouseButton(0) && tortoiseAnimator.GetInteger("TortoiseStateNumber") != 3)
        {
            if(Vector3.Distance(player.transform.position, tortoise.transform.position) <= playerFlipRange)
            { 
                if (playerAction.nextFlipTime <= Time.time)
                {
                    previousState = tortoiseAnimator.GetInteger("TortoiseStateNumber");
                    tortoiseAnimator.SetInteger("TortoiseStateNumber", 3);
                    playerAction.nextFlipTime = Time.time + playerAction.flipTime;
                    playerAction.resetRecharge();
                }
            }
            
            //Invoke("resetTortoiseState", pauseTime);
        }
        
    }


    private void resetTortoiseState()
    {
        tortoiseAnimator.SetInteger("TortoiseStateNumber", previousState);
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "tortoise")
        {
            //Debug.Log("registering tortoise collision");
            tortoiseAnimator.SetInteger("TortoiseStateNumber", 1);
            collision.gameObject.GetComponent<Animator>().SetInteger("TortoiseStateNumber", 4);
            collision.gameObject.GetComponent<Animator>().SetInteger("TortoiseStateNumber", 1);
        }
        if (collision.gameObject.GetComponent<Food>() != null)
        {
            //Debug.Log("is colliding wi something with food script");
            foodBeingEaten = collision.gameObject;
        }

        //Debug.Log("registering collision");
        //tortoiseAnimator.SetInteger("TortoiseStateNumber", 1);
        //collision.gameObject.GetComponent<Animator>().SetInteger("TortoiseStateNumber", 4);
        //collision.gameObject.GetComponent<Animator>().SetInteger("TortoiseStateNumber", 1);

    }

    //private void OnCollisionExit(Collision collision)
    //{
    //    tortoiseAnimator.SetInteger("TortoiseStateNumber", 1);
    //}

    private void resetAfterEating()
    {
        if(tortoiseAnimator.GetInteger("TortoiseStateNumber") == 2 && foodBeingEaten == null)
        {
            Debug.Log("food has been destroyed");
            tortoiseAnimator.SetInteger("TortoiseStateNumber", 1);
        }
        
    }
}
