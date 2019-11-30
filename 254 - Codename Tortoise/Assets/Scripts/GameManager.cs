using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int thisLevelRef;
    public GlobalObject GlobObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // MANAGING LEVELS

    public void unlockNextLevel()
    {
        GlobObj.unlockLevel(thisLevelRef + 1);
    }

    // MANAGING SCENES

    public void StartGame()
    {
        //load menu screen
        SceneManager.LoadScene("OpenScreen");
    }

    public void openLevelSelect()
    {
        SceneManager.LoadScene("LevelSelection");
    }

    public void openSample()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void LevelOne()
    {

    }

    public void endScreenWin()
    {
        SceneManager.LoadScene("WinLevel");
    }

    public void endScreenLose()
    {
        SceneManager.LoadScene("LoseLevel");
    }

    public void endGame()
    {

    }
}
