﻿using UnityEngine;
using System.Collections;

public class TurnManager : MonoBehaviour {

    private MessageManager messageManager;
    private CharacterManager characterManager;
    private EnemyMove enemyMove;
    private bool gameLock = false;

    void Start()
    {
        messageManager = FindObjectOfType<MessageManager>();
        characterManager = FindObjectOfType<CharacterManager>();
        enemyMove = FindObjectOfType<EnemyMove>();

        Invoke("beginPlayerTurn", 2.0f);
    }

    public void startPlayerTurn()
    {
        if (!gameLock)
        {
            Invoke("beginPlayerTurn", 2.0f);
        }
    }

    public void startComputerTurn()
    {
        if (!gameLock)
        {
            Invoke("showComputerTurnMsg", 2.0f);
            Invoke("beginComputerTurn", 2.0f);
        }
    }

    private void showComputerTurnMsg()
    {
        messageManager.enemyTurnMsg();
    }

    public void lockUserMoves()
    {
        characterManager.setActive(false);
    }

    public void playerWin()
    {
        gameLock = true;
        lockUserMoves();
        messageManager.youWinMsg();
    }

    public void gameOver()
    {
        gameLock = true;
        lockUserMoves();
        messageManager.youLostMsg();
    }

    private void beginPlayerTurn()
    {
        messageManager.playerTurnMsg();

        characterManager.setActive(true);
    }

    private void beginComputerTurn()
    {
        enemyMove.move();
    }
}
