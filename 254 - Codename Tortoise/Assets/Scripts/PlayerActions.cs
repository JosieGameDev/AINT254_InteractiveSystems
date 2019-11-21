using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{

    // vars

    //actions
    public Actions flipTortoise;
    public float flipTime = 3f;
    public RechargeBars flipRechargeBar;

    private Actions throwDecoyFood;
    private float spawnRate = 3f;
    public RechargeBars spawnRechargeBar;
    public GameObject spawnedDecoy;

    private Actions yellAtTortoise;
    public float yellRate = 3f;
    public RechargeBars yellRechargeBars;
    public float yellRange = 5;
    public float yellTime = 3f;
    public GameObject yellRangeUI;
    public NoiseImpact noiseAOE;
    public GameObject noiseTrigger;

    private Actions testEmptyAction;

    private Actions currentAction;
    public int currentActionIndex = 1;
    private GameObject currentTortoise;

    
    // Start is called before the first frame update
    void Start()
    {
        // create new actions 
        flipTortoise = new Actions(flipTime, flipRechargeBar);
        throwDecoyFood = new Actions(spawnRate, spawnRechargeBar, spawnedDecoy);
        yellAtTortoise = new Actions(yellRate, yellRechargeBars);

        //set current action
        currentAction = throwDecoyFood;
        yellRangeUI.SetActive(false);

        //set up spook ui circle
        //noiseImpactAreaTrigger = yellRangeUI.GetComponent<SphereCollider>();
        noiseTrigger.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //throwDecoy(spawnedDecoy);
        flipTortoise.UpdateRechargeBar();
        throwDecoyFood.UpdateRechargeBar();
        yellAtTortoise.UpdateRechargeBar();

        if(Input.GetMouseButton(1))
        {
            runCurrentAction();
        }

        checkSpaceInput();

        //Debug.Log(currentAction);
    }

    public void checkSpaceInput()
    {
        //if(Input.mouseScrollDelta.y !=  0)
        if(Input.GetKeyDown("space"))
        {
            
            changeCurrentAction();
            
        }
    }

    public void runCurrentAction()
    {
        if(currentActionIndex == 1)
        {
            throwDecoyAction();
        }
        else if(currentActionIndex == 2)
        {
            yellAction();
        }
    }

    public void changeCurrentAction()
    {

        if(currentActionIndex == 1)
        {
            yellRangeUI.SetActive(true);
            currentActionIndex = 2;
        }
        else if (currentActionIndex == 2)
        {
            yellRangeUI.SetActive(false);
            currentActionIndex = 1;
        }

        
    
       
    }


    private void throwDecoyAction()
    {
        
        if(throwDecoyFood.checkChargeReadyForAction() == true)
        {
            Vector3 dropPt = this.gameObject.transform.position;
            dropPt.x -= 2;
            throwDecoyFood.spawnAction(dropPt);
            throwDecoyFood.setNextChargeTime(Time.time);
        }
    }

    private void yellAction()
    {

       

        if(yellAtTortoise.checkChargeReadyForAction() == true)
        {

            //play anim
            StartCoroutine(setYellUIAnim());
            //get array of tortoise
            //GameObject[] tortoisArray = GameObject.FindGameObjectsWithTag("tortoise");
            

            ////check through array to find tortoise within range
            //foreach(GameObject g in tortoisArray)
            //{
            //    if(Vector3.Distance(this.transform.position, g.transform.position) <= yellRange )
            //    {
                   
            //        StartCoroutine(yellAndReset(g));
            //    }
            //}



            yellAtTortoise.setNextChargeTime(Time.time);
            
        }
    }
    

    public IEnumerator yellAndReset(GameObject g)
    {

        
        g.GetComponent<Animator>().SetInteger("TortoiseStateNumber", 4);
        
        //currentTortoise = g;
        yield return new WaitForSeconds(yellTime);
        g.GetComponent<Animator>().SetInteger("TortoiseStateNumber", 1);
    }

    public IEnumerator setYellUIAnim()
    {
        // set anim and turn on collider for trigger events
        yellRangeUI.GetComponent<Animator>().SetBool("isShouting", true);
        yield return new WaitForSeconds(0.2f);
        noiseTrigger.SetActive(true);
        yield return new WaitForSeconds(1f);
        yellRangeUI.GetComponent<Animator>().SetBool("isShouting", false);
        noiseTrigger.SetActive(false);
    }
    
}
