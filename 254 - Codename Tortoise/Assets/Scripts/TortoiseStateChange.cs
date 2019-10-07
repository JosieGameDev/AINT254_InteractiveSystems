using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TortoiseStateChange : MonoBehaviour
{
    // VARIABLES
    public GameObject tortoise;
    public Animator tortoiseAnimator;
    public int previousState;
    public float pauseTime = 3f;

    // Start is called before the first frame update
    void Start()
    {
        tortoise = this.gameObject;
        tortoiseAnimator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        if(Input.GetMouseButton(0) && tortoiseAnimator.GetInteger("TortoiseStateNumber") != 3)
        {
            
            previousState = tortoiseAnimator.GetInteger("TortoiseStateNumber");
            tortoiseAnimator.SetInteger("TortoiseStateNumber", 3);
            Invoke("resetTortoiseState", pauseTime);
        }
    }

    private void resetTortoiseState()
    {
        tortoiseAnimator.SetInteger("TortoiseStateNumber", previousState);
    }
}
