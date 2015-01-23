using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    private bool isActive = true;
    private AudioSource audioSource;
    private TurnManager turnManager;

    public AudioClip inDestroySound;
    public AudioClip inDeathSound;
    public AudioClip inCastleHitSound;
    public AudioClip inWoodHitSound;
    public AudioClip inArrowHitCastleSound;

    // Return if bullet is active
    public bool getActive()
    {
        return isActive;
    }

	// Use this for initialization
    void Start()
    {
        turnManager = FindObjectOfType<TurnManager>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isActive)
        {
            isActive = false;

            // If collision with wheel - player wins
            if (collision.gameObject.tag == "wheel")
            {
                // Play destroy sound
                audioSource.clip = inDestroySound;
                audioSource.Play();

                // Start destroy animation
                collision.gameObject.GetComponent<Animator>().SetInteger("state", 1);

                // Make collider smaller
                BoxCollider2D wheelCollider = collision.gameObject.GetComponent<BoxCollider2D>();
                wheelCollider.size = new Vector2(0.69f, 0.3f);
                Vector2 center = wheelCollider.center;
                center.y -= 0.15f;
                wheelCollider.center = center;

                // Player wins
                Gate gate = FindObjectOfType<Gate>();
                gate.open();
                turnManager.playerWin();
            }
            // If collision with enemy
            else if (collision.gameObject.tag == "enemy")
            {
                // Enemy kill (stop moving)
                Level1 enemyMove = (Level1)collision.collider.gameObject.GetComponent<Level1>();

                if (enemyMove != null && enemyMove.getAlive())
                {
                    // Play death sound
                    audioSource.clip = inDeathSound;
                    audioSource.Play();

                    // Enemy hit
                    Animator enemyAnimator = collision.collider.gameObject.GetComponent<Animator>();
                    enemyAnimator.SetInteger("state", 2);
                    collision.collider.GetComponent<BoxCollider2D>().size = new Vector2(0.34f, 0.25f);

                    if (enemyMove)
                    {
                        enemyMove.kill();
                    }
                }

                // End user turn
                turnManager.startComputerTurn();
            }
            else
            {
                if (collision.gameObject.tag == "castle")
                {
                    // Play castle_hit sound
                    audioSource.clip = inCastleHitSound;
                    audioSource.Play();
                }

                if (collision.gameObject.tag == "wood" || collision.gameObject.tag == "gate")
                {
                    // Play castle_hit sound
                    audioSource.clip = inWoodHitSound;
                    audioSource.Play();
                }

                if (collision.gameObject.tag == "arrowCollider" && gameObject.tag == "fireBullet")
                {
                    // Play castle_hit sound
                    audioSource.clip = inArrowHitCastleSound;
                    audioSource.Play();
                }

                // End user turn
                turnManager.startComputerTurn();
            }
        }
    }
}
