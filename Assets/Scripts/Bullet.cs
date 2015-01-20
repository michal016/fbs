using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    private bool isActive = true;
    private AudioSource audioSource;
    private TurnManager turnManager;

    public AudioClip inDestroySound;
    public AudioClip inDeathSound;
    public AudioClip inCastleHitSound;

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

            if (collision.gameObject.tag == "wheel")
            {
                // Play destroy sound
                audioSource.clip = inDestroySound;
                audioSource.Play();

                collision.gameObject.GetComponent<Animator>().SetInteger("state", 1);

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
            else if (collision.gameObject.tag == "enemy")
            {
                // Play death sound
                audioSource.clip = inDeathSound;
                audioSource.Play();

                // Enemy hit
                Animator enemyAnimator = collision.collider.gameObject.GetComponent<Animator>();
                enemyAnimator.SetInteger("state", 2);

                collision.collider.GetComponent<BoxCollider2D>().size = new Vector2(0.34f, 0.25f);

                // Enemy kill (stop moving)
                EnemyMove enemyMove = (EnemyMove)collision.collider.gameObject.GetComponent<EnemyMove>();

                if (enemyMove)
                {
                    enemyMove.kill();
                }
                //// Player wins
                //Gate gate = FindObjectOfType<Gate>();
                //gate.open();
                //turnManager.playerWin();

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

                // End user turn
                turnManager.startComputerTurn();
            }
        }
    }
}
