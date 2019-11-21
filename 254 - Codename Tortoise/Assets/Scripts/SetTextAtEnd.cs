using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetTextAtEnd : MonoBehaviour
{
    private TextMeshProUGUI TMP_TextToSet;
    public GameObject TextToSet;
    private GameObject GameManObj;
    private GlobalObject GO;
    public bool displayTime = false;
    public bool displayHealth = true;
    //public string starRating;
    // Start is called before the first frame update
    void Start()
    {
        TMP_TextToSet = TextToSet.GetComponent<TextMeshProUGUI>();
        Debug.Log(TMP_TextToSet);
        Debug.Log(TMP_TextToSet.text);
        GameManObj = GameObject.FindGameObjectWithTag("GlobalObject");
        GO = GameManObj.GetComponent<GlobalObject>();

        if(displayTime == true)
        {
            TMP_TextToSet.text = "Your lettuce was all eaten! And with just " + GO.timeRemaining.ToString() + " seconds left!";
        }
        else if(displayHealth == true)
        {
            TMP_TextToSet.text = "Your lettuce survived! Well, " + GO.healthLeft + "% of it survived, at least. STAR RATING =" + getStarRating();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string getStarRating()
    {
        string starRating;

        if(GO.healthLeft >= 70)
        {
            starRating = "***";
        }
        else if (GO.healthLeft >=40)
        {
            starRating = "**";
        }
        else
        {
            starRating = "*";
        }

        return starRating;
    }
}
