using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetTextAtEnd : MonoBehaviour
{
    private TextMeshProUGUI TMP_TextToSet;
    public GameObject TextToSet;
    private GameObject GlobObjGO;
    private GlobalObject GO;
    public bool displayTime = false;
    public bool displayHealth = true;
    public GameManager gameMan;
    public Image starRateImage;
    public int nextLevel;
    //public levelManager levelMan;
    //public string starRating;
    // Start is called before the first frame update
    void Start()
    {
        TMP_TextToSet = TextToSet.GetComponent<TextMeshProUGUI>();
        Debug.Log(TMP_TextToSet);
        Debug.Log(TMP_TextToSet.text);
        GlobObjGO = GameObject.FindGameObjectWithTag("GlobalObject");
        GO = GlobObjGO.GetComponent<GlobalObject>();

        if(displayTime == true)
        {
            TMP_TextToSet.text = "Your lettuce was all eaten! And with just " + GO.timeRemaining.ToString() + " seconds left!";
        }
        else if(displayHealth == true)
        {
            TMP_TextToSet.text = "Your lettuce survived! Well, " + GO.healthLeft + "% of it survived, at least.";
            displayStarRating();
            GO.unlockLevel(nextLevel);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void displayStarRating()
    {
        if(GO.refOfLevelJustPlayed == 0)
        {
            starRateImage.sprite = GO.levelOneStars;
            nextLevel = 1;
        }
        if (GO.refOfLevelJustPlayed == 1)
        {
            starRateImage.sprite = GO.levelTwoStars;
            nextLevel = 2;
        }
        if (GO.refOfLevelJustPlayed == 2)
        {
            starRateImage.sprite = GO.levelThreeStars;
            nextLevel = 3;
        }
    }
}
