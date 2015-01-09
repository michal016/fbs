using UnityEngine;
using System.Collections;

public class TurnManager : MonoBehaviour {

    // 0 - player, 1 - computer
    //private int turn = 0;

    public void setTurn(int t)
    {
        //turn = t;


        if (t == 0)
        {
            Invoke("startPlayerTurn", 2.0f);
        }
        else
        {
            Invoke("startComputerTurn", 2.0f);
        }
    }

    private void startPlayerTurn()
    {
        CharacterManager characterManager = FindObjectOfType<CharacterManager>();
        characterManager.setActive(true);
    }

    private void startComputerTurn()
    {
        CharacterManager characterManager = FindObjectOfType<CharacterManager>();
        characterManager.setActive(false);

        EnemyMove enemyMove = GetComponentInChildren<EnemyMove>();
        enemyMove.move();
    }

    private void pause()
    {
        CharacterManager characterManager = FindObjectOfType<CharacterManager>();
        characterManager.setActive(false);
    }
    
    
    
    
    
    
    
    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
