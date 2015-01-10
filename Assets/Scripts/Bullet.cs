using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    private bool isActive = true;
    private TurnManager turnManager;

    public bool getActive()
    {
        return isActive;
    }

	// Use this for initialization
    void Start()
    {
        turnManager = FindObjectOfType<TurnManager>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isActive)
        {
            isActive = false;

            if (collision.gameObject.tag == "wheel")
            {
                // Player wins
                Gate gate = FindObjectOfType<Gate>();
                gate.open();
                turnManager.playerWin();
            }
            else if (collision.gameObject.tag == "enemy")
            {
                // Enemy hit
                Animator enemyAnimator = collision.collider.gameObject.GetComponent<Animator>();
                enemyAnimator.SetInteger("state", 2);

                collision.collider.GetComponent<BoxCollider2D>().size = new Vector2(0.34f, 0.25f);

                // Player wins
                Gate gate = FindObjectOfType<Gate>();
                gate.open();
                turnManager.playerWin();
            }
            else
            {
                // End user turn
                turnManager.startComputerTurn();
            }
        }
    }
}
