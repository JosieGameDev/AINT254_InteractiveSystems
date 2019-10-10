using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour
{

    //Vars
    #region
    private GameObject ChaserGO;
    private GameObject TargetGO;
    public float speed = 5f;
    private Vector3 ChaserVector = new Vector3(0,0,0);
    private Vector3 TargetVector = new Vector3(0, 0, 0);
    private Vector3 VectorDirection;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        ChaserGO = this.gameObject;
        TargetGO = GameObject.FindGameObjectWithTag("Target");
    }

    // Update is called once per frame
    void Update()
    {
        ChaserVector = new Vector3(ChaserGO.transform.position.x, ChaserGO.transform.position.y, ChaserGO.transform.position.z);
        TargetVector = new Vector3(TargetGO.transform.position.x, TargetGO.transform.position.y, TargetGO.transform.position.z);

        Vector3 resultVector =  Vector3.Cross(ChaserVector, TargetVector);
        Debug.Log("result vector is " + resultVector);

        //normalise vector
        VectorDirection = resultVector / resultVector.magnitude;

        Debug.Log("direction is " + VectorDirection);
    }
}
