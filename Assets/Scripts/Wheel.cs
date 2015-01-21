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

    public void destroy()
    {
        audioSource.Play();
        GetComponent<Animator>().SetInteger("state", 1);


        Gate gate = FindObjectOfType<Gate>();
        gate.open();

        // Player wins
        turnManager.playerWin();
    }
}
