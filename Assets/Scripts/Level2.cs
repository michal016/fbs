using UnityEngine;
using System.Collections;

// Class used to make computer moves in the second level
public class Level2 : MonoBehaviour {

    public AudioClip inDestroySound;
    private Animator animator;
    private AudioSource audioSource;
    private Gate gate;
    private int stopFrame = 60;
    private bool closingGate = false;
    private bool openingGate = false;
    private bool isAlive = true;
    private bool movement = false;
    private int movementFrame = 0;
    TurnManager turnManager;

    // Use this for initialization
    void Start()
    {
        rigidbody2D.centerOfMass = new Vector2(0, -0.5f);
        audioSource = GetComponent<AudioSource>();
        turnManager = FindObjectOfType<TurnManager>();
        animator = gameObject.GetComponent<Animator>();
        gate = FindObjectOfType<Gate>();
    }

    // Update is called once per frame
    void Update()
    {

        // If computer is moveing
        if (movement)
        {
            Vector3 position = transform.position;
            position.x -= 0.02f;
            transform.position = position;

            if (movementFrame < stopFrame)
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

        // Open the gate
        if (openingGate)
        {
            // when opening finished
            if (!gate.isOpening())
            {
                // Start animation
                animator.SetInteger("state", 1);
                audioSource.Play();
                movement = true;

                openingGate = false;
            }
        }

        // If gate is being closed
        if (closingGate)
        {
            if (!gate.isClosing())
            {
                closingGate = false;
            }
        }
    }

    // Start computer move
    public void move(int turn)
    {

        if (isAlive)
        {
            if (turn < 4)
            {
                // start move
                animator.SetInteger("state", 1);
                audioSource.Play();
                movement = true;
                //// Start user turn
                //turnManager.startPlayerTurn();
            }

            // Start the crusader bloody walk
            if (turn >= 4)
            {
                stopFrame = 1000;
                openingGate = true;
                gate.open();
            }

            //if (turn == 5)
            //{
            //    animator.SetInteger("state", 1);
            //    audioSource.Play();
            //    movement = true;

            //    closingGate = true;
            //    gate.close();
            //}

            //if (turn > 5)
            //{
            //    animator.SetInteger("state", 1);
            //    audioSource.Play();
            //    movement = true;
            //}
        }
    }

    IEnumerator OnCollisionEnter2D(Collision2D collision)
    {
        // When crusader collides with player - kill player
        if (collision.gameObject.tag == "Player")
        {
            audioSource.Stop();
            movement = false;

            // start animation
            animator.SetInteger("state", 2);
            Invoke("gameOver", 1.0f);

            yield return new WaitForSeconds(0.4f);

            // Stop animation
            animator.SetInteger("state", 0);
            collision.collider.GetComponent<Animator>().SetInteger("state", 4);
            AudioSource catapultAudioSource = collision.collider.GetComponent<AudioSource>();

            // Play sound
            catapultAudioSource.clip = inDestroySound;
            catapultAudioSource.Play();
            collision.collider.GetComponent<BoxCollider2D>().size = new Vector2(1.19f, 0.4f);
        }
    }

    // Call game over
    private void gameOver()
    {
        turnManager.gameOver();
    }


}
