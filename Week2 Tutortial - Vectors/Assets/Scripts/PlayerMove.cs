using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    // VARS
    #region
    private GameObject Player;
    public float speed = 5f;
    private float x, z;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        Player = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        Player.transform.Translate(x, 0, z * Time.deltaTime);
    }

   
}
