using UnityEngine;
using System.Collections;

public class Level2 : MonoBehaviour {

    public AudioClip inDestroySound;

    private Animator animator;
    private AudioSource audioSource;
    private Gate gate;

    private bool closingGate = false;
    private bool openingGate = false;
    public bool isAlive = true;
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

        if (movement)
        {
            Vector3 position = transform.position;
            position.x -= 0.02f;
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

        if (openingGate)
        {
            if (!gate.isOpening())
            {

                animator.SetInteger("state", 1);
                audioSource.Play();
                movement = true;

                openingGate = false;
            }
        }

        if (closingGate)
        {
            if (!gate.isClosing())
            {


                closingGate = false;
            }
        }
    }

    public void move(int turn)
    {

        if (isAlive)
        {
            if (turn < 3)
            {
                // Start user turn
                turnManager.startPlayerTurn();
            }

            if (turn == 3)
            {
                openingGate = true;
                gate.open();
            }

            if (turn == 4)
            {
                animator.SetInteger("state", 1);
                audioSource.Play();
                movement = true;

                closingGate = true;
                gate.close();
            }

            if (turn > 4)
            {
                animator.SetInteger("state", 1);
                audioSource.Play();
                movement = true;
            }
        }
        else
        {
            // Start user turn
            turnManager.startPlayerTurn();
        }
    }

    IEnumerator OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            audioSource.Stop();
            movement = false;


            animator.SetInteger("state", 2);
            Invoke("gameOver", 1.0f);

            yield return new WaitForSeconds(0.4f);

            animator.SetInteger("state", 0);
            collision.collider.GetComponent<Animator>().SetInteger("state", 4);
            AudioSource catapultAudioSource = collision.collider.GetComponent<AudioSource>();


            catapultAudioSource.clip = inDestroySound;
            catapultAudioSource.Play();
            collision.collider.GetComponent<BoxCollider2D>().size = new Vector2(1.19f, 0.4f);
        }
    }

    private void gameOver()
    {
        turnManager.gameOver();
    }


}
