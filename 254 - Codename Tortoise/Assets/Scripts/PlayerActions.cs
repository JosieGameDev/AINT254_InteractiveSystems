using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{

    // vars
    public GameObject spawnedDecoy;
    public int zAdjustment = 10;
    private float nextFireTime = 0f;
    private float fireRate = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        throwDecoy(spawnedDecoy);

        if(Time.time - fireRate > nextFireTime)
        {
            if(nextFireTime < Time.time)
            {
                throwDecoy(spawnedDecoy);
            }
        }
    }

    private void throwDecoy(GameObject SpawnedObject)
    {
        // SCRIPT TO THROW DECOY VEG ONTO FLOOR

        if (Input.GetMouseButton(1))
        {
            if (nextFireTime <= Time.time)
            {
                // on right click

                Vector3 ClickPoint = Input.mousePosition;
                ClickPoint.z = zAdjustment;
                ClickPoint = Camera.main.ScreenToWorldPoint(ClickPoint);
                Debug.Log(ClickPoint);
                ClickPoint.y = 1;
                Debug.Log(ClickPoint);

                Instantiate(SpawnedObject, ClickPoint, Quaternion.identity);
                nextFireTime = Time.time + fireRate;
            }
        }
    }
}
