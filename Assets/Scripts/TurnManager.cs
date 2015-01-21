using UnityEngine;
using System.Collections;

public class TurnManager : MonoBehaviour {

    public AudioClip inWinSound;
    public AudioClip inLoseSound;
    public int inLevel;
    private AudioSource audioSource;

    private LevelManager levelManager;
    private MessageManager messageManager;
    private CharacterManager characterManager;
    private bool gameLock = false;
    private int turn = 0;
    private bool levelCompleted = false;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();

        levelManager = FindObjectOfType<LevelManager>();
        messageManager = FindObjectOfType<MessageManager>();
        characterManager = FindObjectOfType<CharacterManager>();

        Invoke("beginPlayerTurn", 2.0f);
    }

    public void startPlayerTurn()
    {
        if (!levelCompleted)
        {
            if (!gameLock)
            {
                Invoke("beginPlayerTurn", 2.0f);
            }
        }
    }

    public void startComputerTurn()
    {
        if (!levelCompleted)
        {
            if (!gameLock)
            {
                messageManager.enemyTurnMsg();
                Invoke("beginComputerTurn", 2.0f);
            }
        }
    }

    public void lockUserMoves()
    {
        characterManager.setActive(false);
    }

    public void playerWin()
    {
        audioSource.clip = inWinSound;
        audioSource.Play();

        gameLock = true;
        lockUserMoves();
        messageManager.youWinMsg(turn);

        GameState.setStars(inLevel - 1, turn);

        SaveLoad.Save();
        levelCompleted = true;
    }

    public void gameOver()
    {
        if (!levelCompleted)
        {
            audioSource.clip = inLoseSound;
            audioSource.Play();

            gameLock = true;
            lockUserMoves();
            messageManager.youLostMsg();
            levelCompleted = true;
        }
    }

    private void beginPlayerTurn()
    {
        turn++;
        messageManager.playerTurnMsg();
        characterManager.setActive(true);
    }

    private void beginComputerTurn()
    {
        levelManager.computerTurn(turn);
    }

    void Update()
    {
        if (levelCompleted)
        {
            if (Input.GetKey(KeyCode.Space) == true)
            {
                Application.LoadLevel("menu");
            }
        }
    }
}
