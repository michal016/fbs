using UnityEngine;
using System.Collections;

public class BrokenDeck : MonoBehaviour {

    private bool isActive = true;
    private AudioSource audioSource;
    private TurnManager turnManager;

    // Use this for initialization
    void Start()
    {
        turnManager = FindObjectOfType<TurnManager>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Detect collision with wheel
        if (collision.gameObject.tag == "wheel")
        {
            if (isActive)
            {
                isActive = false;

                // Play destroy sound
                audioSource.Play();

                // Wheel destroy animation
                collision.gameObject.GetComponent<Animator>().SetInteger("state", 1);

                // Player wins
                Gate gate = FindObjectOfType<Gate>();
                gate.open();
                turnManager.playerWin();
            }
        }
    }
}
