using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

    void Start()
    {
        Transform tr = transform.Find("Level1");
    }

    public void startLevel1()
    {
        if (GameState.isLevelEnabled(1))
        {
            Application.LoadLevel("level_1");
        }
    }

    public void startLevel2()
    {
        if (GameState.isLevelEnabled(2))
        {
            Application.LoadLevel("level_2");
        }
    }

    public void startLevel3()
    {
        if (GameState.isLevelEnabled(3))
        {
            Application.LoadLevel("level_3");
        }
    }
}
