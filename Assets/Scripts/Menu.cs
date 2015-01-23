using UnityEngine;
using System.Collections;

// Class used to start other scenes
public class Menu : MonoBehaviour {

    void Start()
    {
        Transform tr = transform.Find("Level1");
    }

    // Handle 1st level button click
    public void startLevel1()
    {
        if (GameState.isLevelEnabled(1))
        {
            Application.LoadLevel("level_1");
        }
    }

    // Handle 2nd level button click
    public void startLevel2()
    {
        if (GameState.isLevelEnabled(2))
        {
            Application.LoadLevel("level_2");
        }
    }

    // Handle 3rd level button click
    public void startLevel3()
    {
        if (GameState.isLevelEnabled(3))
        {
            Application.LoadLevel("level_3");
        }
    }

    // Exit the application
    public void quitGame()
    {
        Application.Quit();
    }
}
