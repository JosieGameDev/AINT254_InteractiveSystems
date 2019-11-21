using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseImpact : MonoBehaviour
{
    //vars
    public float spookTime = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "tortoise")
        {
            StartCoroutine(spookAndReset(other.gameObject));
        }
        
    }

    public IEnumerator spookAndReset(GameObject g)
    {
        //change tortoise state for given time

        g.GetComponent<Animator>().SetInteger("TortoiseStateNumber", 4);

        //currentTortoise = g;
        yield return new WaitForSeconds(spookTime);
        g.GetComponent<Animator>().SetInteger("TortoiseStateNumber", 1);
    }
}
