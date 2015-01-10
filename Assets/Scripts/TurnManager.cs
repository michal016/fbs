﻿using UnityEngine;
using System.Collections;

public class TurnManager : MonoBehaviour {

    public void startPlayerTurn()
    {
        Invoke("beginPlayerTurn", 2.0f);
    }

    public void startComputerTurn()
    {
        Invoke("beginComputerTurn", 2.0f);
    }

    public void pause()
    {
        CharacterManager characterManager = FindObjectOfType<CharacterManager>();
        characterManager.setActive(false);
    }

    private void beginPlayerTurn()
    {
        CharacterManager characterManager = FindObjectOfType<CharacterManager>();
        characterManager.setActive(true);
    }

    private void beginComputerTurn()
    {
        EnemyMove enemyMove = FindObjectOfType<EnemyMove>();
        enemyMove.move();
    }
    
    
    
    
    
    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
