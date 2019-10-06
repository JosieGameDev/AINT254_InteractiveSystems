using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tortoise : MonoBehaviour
{

    // VARIABLES
    public Transform lettuceTransform;
    private GameObject tortoise;
    public float speed = 1f;


    // Start is called before the first frame update
    void Start()
    {
        tortoise = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        tortoise.transform.position = Vector3.MoveTowards(tortoise.transform.position, lettuceTransform.position, speed);
    }
}
