using UnityEngine;
using System.Collections;

public class Wheel : MonoBehaviour {

    private AudioSource audioSource;
    private TurnManager turnManager;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        turnManager = FindObjectOfType<TurnManager>();
    }

    // Destroy wheel
    public void destroy()
    {
        // Start sound playing and animation
        audioSource.Play();
        GetComponent<Animator>().SetInteger("state", 1);

        // Open gate
        Gate gate = FindObjectOfType<Gate>();
        gate.open();

        // Player wins
        turnManager.playerWin();
    }
}
