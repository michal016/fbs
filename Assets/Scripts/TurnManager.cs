using UnityEngine;
using System.Collections;

public class TurnManager : MonoBehaviour {

    // 0 - player, 1 - computer
    private int turn = 0;

    public void setTurn(int t)
    {
        turn = t;

        CharacterManager characterManager = GetComponentInChildren<CharacterManager>();

        if (t == 0)
        {
            // player turn
            characterManager.setActive(true);
        }
        else
        {
            // computer turn
            characterManager.setActive(false);

            EnemyMove enemyMove = GetComponentInChildren<EnemyMove>();
            enemyMove.move();
        }
    }
    
    
    
    
    
    
    
    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
