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

    public float nextFlipTime = 0f;
    public float flipTime = 3f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        throwDecoy(spawnedDecoy);

    }

    private void throwDecoy(GameObject SpawnedObject)
    {
        // SCRIPT TO THROW DECOY VEG ONTO FLOOR

        if (Input.GetMouseButton(1))
        {
            if (nextSpawnTime <= Time.time)
            {
                // on right click

                //spawn at click point
                //Vector3 ClickPoint = Input.mousePosition;
                //ClickPoint.z = zAdjustment;
                //ClickPoint = Camera.main.ScreenToWorldPoint(ClickPoint);
                //Debug.Log(ClickPoint);
                //ClickPoint.y = 1;
                //Debug.Log(ClickPoint);

                //spawn behind player
                Vector3 ClickPoint = this.gameObject.transform.position;
                ClickPoint.x += 2;

                Instantiate(SpawnedObject, ClickPoint, Quaternion.identity);
                nextSpawnTime = Time.time + spawnRate;
            }
        }
    }
}
