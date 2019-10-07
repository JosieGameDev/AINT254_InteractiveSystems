using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TortoiseMove : MonoBehaviour
{
    // VARIABLES
    #region
    public Transform goalTransform;
    private GameObject tortoise;
    public float speed = 1f;
    public float safeDistance = 2f;

    #endregion
    void Start()
    {
        tortoise = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(tortoise.transform.position, goalTransform.position) >= safeDistance)
        {
            tortoise.transform.position = Vector3.MoveTowards(tortoise.transform.position, goalTransform.position, speed);
        }
    }
}
