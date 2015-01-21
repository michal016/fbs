using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public int inLevel;
    private Level1 level1;
    private Level2 level2;



	// Use this for initialization
    void Start()
    {
        level1 = FindObjectOfType<Level1>();
        level2 = FindObjectOfType<Level2>();
	}

    public void computerTurn(int turn)
    {
        if (inLevel == 1)
        {
            computerTurnLevel1(turn);
        }
        else if (inLevel == 2)
        {
            computerTurnLevel2(turn);
        }
        else if (inLevel == 3)
        {
            computerTurnLevel3(turn);
        }
    }

    private void computerTurnLevel1(int turn)
    {
        level1.move(turn);
    }

    private void computerTurnLevel2(int turn)
    {
        level2.move(turn);
    }

    private void computerTurnLevel3(int turn)
    {
    }
}
