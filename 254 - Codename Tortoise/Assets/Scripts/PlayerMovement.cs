using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //VARIABLES 
    #region
    private Rigidbody playerRB;
    public float speed = 3f;
    private Vector3 inputs = Vector3.zero;
    public float playerAdjustAngle;


    #endregion

    // Start is called before the first frame update
    void Start()
    {
        playerRB = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        inputs.x = Input.GetAxis("Horizontal");
        inputs.z = Input.GetAxis("Vertical");
    
    }

    private void FixedUpdate()
    {
        playerRB.MovePosition(playerRB.position + inputs * speed * Time.deltaTime);
        if(inputs != Vector3.zero)
        {
            playerRB.transform.forward = inputs;
        }
        
    }
}
