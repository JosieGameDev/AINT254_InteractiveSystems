using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalObject : MonoBehaviour
{
    //this
    public static GlobalObject Instance;
    //vars
    public float healthLeft;
    public double timeRemaining;

    public bool[] unlockedLevels;

    public Sprite levelOneStars;
    public Sprite levelTwoStars;
    public Sprite levelThreeStars;

    private void Awake()
    {
        unlockedLevels = new bool[3] { true, false, false };

        if(Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void unlockLevel(int levelRef)
    {
        unlockedLevels[levelRef] = true;
    }

    public bool checkLevelUnlocked(int levelRef)
    {
        return unlockedLevels[levelRef];
    }

    //// Start is called before the first frame update
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}
}
