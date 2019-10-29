using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RechargeBars : MonoBehaviour
{

    //vars
    public Slider rechargeSlider;
    public float maxSliderValue;
    //public float currentSliderValue;


    // Start is called before the first frame update
    void Start()
    {
        rechargeSlider = GetComponent<Slider>();
        rechargeSlider.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setMaxValue(float maxValue)
    {
        maxSliderValue = maxValue;
    }
    

    public void setRechargeValueWholeNums(float newValue)
    {
        if (newValue < maxSliderValue)
        {
            //set the slider value as a % of the total
            rechargeSlider.value = newValue / maxSliderValue;
        }
        else if (newValue >= maxSliderValue)
        {
            rechargeSlider.value = 1;
        }
    }

    public void setRechargeValue(float newPercent)
    {

        
        if(newPercent < 1)
        {
            rechargeSlider.value = newPercent;
        }
        if(newPercent >= 1)
        {
            rechargeSlider.value = 1;
        }
    }

    public void resetRecharge()
    {
        rechargeSlider.value = 0;
    }
}
