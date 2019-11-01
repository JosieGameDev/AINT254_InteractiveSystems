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

    public Actions throwDecoyFood;
    private float spawnRate = 3f;
    public RechargeBars spawnRechargeBar;
    public GameObject spawnedDecoy;

    public Actions testEmptyAction;

    public Actions currentAction;

    
    // Start is called before the first frame update
    void Start()
    {
        // create new actions 
        flipTortoise = new Actions(flipTime, flipRechargeBar);
        throwDecoyFood = new Actions(spawnRate, spawnRechargeBar, spawnedDecoy);

        //set current action
        currentAction = throwDecoyFood;
    }

    // Update is called once per frame
    void Update()
    {
        //throwDecoy(spawnedDecoy);
        flipTortoise.UpdateRechargeBar();
        throwDecoyFood.UpdateRechargeBar();

        if(Input.GetMouseButton(1))
        {
            runCurrentAction();
        }

        checkMouseWheelInput();
    }

    public void checkMouseWheelInput()
    {
        if(Input.mouseScrollDelta.y !=  0)
        {
            changeCurrentAction();
        }
    }

    public void runCurrentAction()
    {
        if(currentAction == throwDecoyFood)
        {
            throwDecoyAction();
        }

        if(currentAction == testEmptyAction)
        {
            Debug.Log("Now executing action 2");
        }
    }

    public void changeCurrentAction()
    {
        if(currentAction == throwDecoyFood)
        {
            currentAction = testEmptyAction;
        }
        else if (currentAction == testEmptyAction)
        {
            currentAction = throwDecoyFood;
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
    
}
