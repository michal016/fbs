using UnityEngine;
using System.Collections;

// User's  moves handling
public class CharacterMove : MonoBehaviour
{
    private Animator animator;
    private AudioSource audioSource;
    public float inSpeed = 0.05f;
    private bool isActive = false;
    private TurnManager turnManager;

    // Sets character active
    public void setActive(bool active)
    {
        turnManager = FindObjectOfType<TurnManager>();
        isActive = active;
    }

    // Use this for initialization
    void Start()
    {
        rigidbody2D.centerOfMass = new Vector2(0, -0.5f);
        animator = gameObject.GetComponent<Animator>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            Vector3 pos = transform.localPosition;
            Vector3 scale = transform.localScale;

            // Move left
            if (Input.GetKey(KeyCode.LeftArrow) == true)
            {
                // Play sound
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }

                // Start animation
                animator.SetInteger("state", 1);

                scale.x = -2f;
                pos.x -= inSpeed;
            }

            // Move right
            if (Input.GetKey(KeyCode.RightArrow) == true)
            {
                // Play sound
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }

                // Start animation
                animator.SetInteger("state", 1);

                scale.x = 2f;
                pos.x += inSpeed;
            }

            // Stops animation and sound playing after key release
            if (Input.GetKeyUp(KeyCode.RightArrow) == true || Input.GetKeyUp(KeyCode.LeftArrow) == true)
            {
                animator.SetInteger("state", 0);
                audioSource.Stop();
            }

            transform.localPosition = pos;
            transform.localScale = scale;
        }
    }

    // On falling - game over
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "mainFloor")
        {
            turnManager.gameOver();
        }
        
    }
}
