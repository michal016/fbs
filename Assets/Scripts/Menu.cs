using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

    public void startLevel1()
    {
        Application.LoadLevel("level_1");
    }

    public void startLevel2()
    {
        Application.LoadLevel("level_2");
    }

    public void startLevel3()
    {
        Application.LoadLevel("level_3");
    }
}
