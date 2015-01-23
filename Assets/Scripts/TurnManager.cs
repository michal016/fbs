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

    // Start player's turn
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

    // Start computer turn
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

    // Disable user moves
    public void lockUserMoves()
    {
        characterManager.setActive(false);
    }

    // Player wins (display information and
    // disable moves)
    public void playerWin()
    {
        audioSource.clip = inWinSound;
        audioSource.Play();

        gameLock = true;
        lockUserMoves();

        int stars = calculateStars(inLevel, turn);
        
        messageManager.youWinMsg(stars);
        GameState.setStars(inLevel, stars);

        SaveLoad.Save();
        levelCompleted = true;
    }

    // Player lose (display information and
    // disable moves)
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

    // Begins player turn now
    private void beginPlayerTurn()
    {
        if (!levelCompleted)
        {
            turn++;
            Debug.Log(turn);
            messageManager.playerTurnMsg();
            characterManager.setActive(true);
        }
    }

    // Begins computer turn now
    private void beginComputerTurn()
    {
        if (!levelCompleted)
        {
            levelManager.computerTurn(turn);
        }
    }

    void Update()
    {
        // If level completed - any key backs to menu
        if (levelCompleted)
        {
            if (Input.anyKey)
            {
                Application.LoadLevel("menu");
            }
        }

        // If escape pushed - back to menu
        if (Input.GetKey(KeyCode.Escape) == true)
        {
            Application.LoadLevel("menu");
        }
    }

    // Calculate number of stars
    // Depending on level and turns
    private int calculateStars(int level, int turn)
    {
        if (level == 1)
        {
            return 4 - turn;
        }
        else if (level == 2)
        {
            return 5 - turn;
        }
        else if (level == 3)
        {
            return 6 - turn;
        }
        return 0;
    }
}
