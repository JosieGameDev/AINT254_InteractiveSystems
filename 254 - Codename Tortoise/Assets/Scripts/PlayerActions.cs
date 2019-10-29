using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{

    // vars
    public GameObject spawnedDecoy;
    public int zAdjustment = 10;
    private float nextSpawnTime = 0f;
    private float spawnRate = 3f;
    public RechargeBars spawnRechargeBar;

    public float nextFlipTime = 0f;
    public float flipTime = 3f;
    public RechargeBars flipRechargeBar;


    // Start is called before the first frame update
    void Start()
    {
        //set up recharge bar for spawn
        spawnRechargeBar.setMaxValue(spawnRate);
        //set up recharge bar for flip
        flipRechargeBar.setMaxValue(flipTime);
    }

    // Update is called once per frame
    void Update()
    {
        throwDecoy(spawnedDecoy);
        setFlipRecharge();
    }

    public void setFlipRecharge()
    {
        float timeLeft = nextFlipTime - Time.time;
        if (1 - (timeLeft / flipTime) >= flipTime)
        {
            flipRechargeBar.setRechargeValue(1);
        }
        else
        {
            flipRechargeBar.setRechargeValue(1 - (timeLeft / flipTime));
        }
    }

    public void resetRecharge()
    {
        flipRechargeBar.resetRecharge();
    }

    private void throwDecoy(GameObject SpawnedObject)
    {
        // SCRIPT TO THROW DECOY VEG ONTO FLOOR

        //set timeleft bar
        float timeLeft = nextSpawnTime - Time.time;

        if (nextSpawnTime <= Time.time)
        {
            if (Input.GetMouseButton(1))
            {
               //spawn if time is right and player has done input

                Vector3 ClickPoint = this.gameObject.transform.position;
                ClickPoint.x += 2;

                Instantiate(SpawnedObject, ClickPoint, Quaternion.identity);
                nextSpawnTime = Time.time + spawnRate;

                //reset recharge bar
                spawnRechargeBar.resetRecharge();
            }
            else
            {
                spawnRechargeBar.setRechargeValue((1 - timeLeft / spawnRate));
            }
        }
        else if (nextSpawnTime > Time.time)
        {
            
            spawnRechargeBar.setRechargeValue((1-timeLeft / spawnRate));
        }

       // Debug.Log(1 - (timeLeft / spawnRate));
    }
}
