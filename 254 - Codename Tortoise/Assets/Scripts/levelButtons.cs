using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class levelButtons : MonoBehaviour
{
    private Button button;
    public int levelRef;
    public GlobalObject globObj;

    public Image StarRating;

    // Start is called before the first frame update
    void Start()
    {
        button = gameObject.GetComponent<Button>();
        globObj = GameObject.FindGameObjectWithTag("GlobalObject").GetComponent<GlobalObject>();

        if (globObj.checkLevelUnlocked(levelRef))
        {
            button.interactable = true;
            
        }
        else
        {
            button.interactable = false;
        }

        if(globObj.checkLevelUnlocked(levelRef + 1))
        {
            setStarSprite();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (globObj.checkLevelUnlocked(levelRef))
        {
            button.interactable = true;
        }
        else
        {
            button.interactable = false;
        }

        if (globObj.checkLevelUnlocked(levelRef + 1))
        {
            setStarSprite();
        }
    }

    public void setStarSprite()
    {
        if(levelRef == 0)
        {
            StarRating.sprite = globObj.levelOneStars;
        }
        else if (levelRef == 1)
        {
            StarRating.sprite = globObj.levelTwoStars;
        }
        else if (levelRef == 2)
        {
            StarRating.sprite = globObj.levelThreeStars;
        }
    }
}
