using UnityEngine;
using System.Collections;

public class Level1 : MonoBehaviour {

    private Animator animator;
    private AudioSource audioSource;

    public bool isAlive = true;
    private bool movement = false;
    private int movementFrame = 0;
    TurnManager turnManager;

	// Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        turnManager = FindObjectOfType<TurnManager>();
        animator = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        if (movement)
        {
            Vector3 position = transform.position;
            position.x -= 0.01f;
            transform.position = position;

            if (movementFrame < 100)
            {
                movementFrame++;
            }
            else
            {
                // End movement
                animator.SetInteger("state", 0);
                audioSource.Stop();
                movementFrame = 0;
                movement = false;

                // Start user turn
                turnManager.startPlayerTurn();
            }
        }
	}

    public void move(int turn)
    {
        if (turn == 5)
        {
            Deck deck = (Deck)FindObjectOfType<Deck>();
            if (deck)
            {
                deck.close();
                turnManager.gameOver();
            }
        }

        if (isAlive)
        {
            animator.SetInteger("state", 1);
            audioSource.Play();
            movement = true;
        }
        else
        {
            // Start user turn
            turnManager.startPlayerTurn();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "gameOver")
        {
            Deck deck = (Deck)FindObjectOfType<Deck>();
            deck.close();

            // Game over
            turnManager.gameOver();
        }
    }

    public void kill()
    {
        this.isAlive = false;
    }
}
