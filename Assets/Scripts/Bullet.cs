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
                Gate gate = FindObjectOfType<Gate>();
                gate.open();
            }
            else
            {
                // End user turn
                turnManager.startComputerTurn();
            }
        }
    }
}
