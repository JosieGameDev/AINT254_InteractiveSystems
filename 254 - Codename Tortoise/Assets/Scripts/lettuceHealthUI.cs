using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lettuceHealthUI : MonoBehaviour
{

    public Image healthBar;
    private float lettuceHealth;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void updateLettuceHealth(float healthPercent)
    {
        healthBar.fillAmount = healthPercent / 100;
    }
}
