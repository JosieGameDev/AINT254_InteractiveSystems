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
    }
}
