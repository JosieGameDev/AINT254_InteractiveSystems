using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions : MonoBehaviour
{

    //CLASS WHICH CREATES ACTIONS 

    // VARS
    public float rechargeTime;
    public float nextChargeReadyTime = 0f;
    public RechargeBars UIbar;
    public GameObject spawnObject;
    
    
    // Start is called before the first frame update
    void Start()
    {
        UIbar.setMaxValue(rechargeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Actions(float rechargeTimeInput, RechargeBars UIbarInput)
    {
        //constructor

        this.rechargeTime = rechargeTimeInput;
        this.UIbar = UIbarInput;
    }

    public Actions(float rechargeTimeInput, RechargeBars UIbarInput, GameObject spawnGoInput)
    {
        //constructor

        this.rechargeTime = rechargeTimeInput;
        this.UIbar = UIbarInput;
        this.spawnObject = spawnGoInput;
        
    }

    //GETTERS SETTERS

    public float getNextChargeTime()
    {
        return nextChargeReadyTime;
    }

    public void setNextChargeTime(float currentTime)
    {
        this.nextChargeReadyTime = currentTime + rechargeTime;
    }

    public void UpdateRechargeBar()
    {

        // updates the recharge bar as time ticks down

        float timeLeft = nextChargeReadyTime - Time.time;

        if (1 - (timeLeft / rechargeTime) >= rechargeTime)
        {
            UIbar.setRechargeValue(1);
        }
        else
        {
            UIbar.setRechargeValue(1 - (timeLeft / rechargeTime));
        }
    }

    public void resetUiBar()
    {
        UIbar.resetRecharge();
    }

    public bool checkChargeReadyForAction()
    {
        bool isReady = (Time.time >= nextChargeReadyTime);

        return isReady;
    }

    


    public void spawnAction(Vector3 spawnPos)
    {
        Instantiate(spawnObject, spawnPos, Quaternion.identity);
        UIbar.resetRecharge();
    }
}
