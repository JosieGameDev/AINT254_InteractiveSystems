using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testCode : MonoBehaviour
{
    //vars
    private Transform GOTransform;
    public GameObject cubePrefab;
    private GameObject[] goArray;

    // Start is called before the first frame update
    void Start()
    {
        GOTransform = transform;
        goArray = new GameObject[1000];

        for (int i = 0; i < 999; i++)
        {
            GameObject tempObj = cubePrefab;
            goArray[i] = tempObj;
            goArray[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        complexTest();
        //transformTest();
        instantiateTest();
    }

    public void transformTest()
    {
        for (int i = 0; i < 1000; i++)
        {
            GOTransform.position = Vector3.zero;
            Debug.Log("runningTest");
        }      
        
    }

    public void complexTest()
    {
        for (int i = 0; i < 10000; i++)
        {
            int testInt = 1;
            int testInt2 = testInt;
            testInt++;
            testInt++;

            compObj tempObj = new compObj();

        }
    }

    public void instantiateTest()
    {
        //for (int i = 0; i < 1000; i++)
        //{
        //    GameObject tempObj = Instantiate(cubePrefab);
        //    tempObj.transform.position = new Vector3(1,3,4);
        //    Destroy(tempObj);
        //}

        
    }
}
