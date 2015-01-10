using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    private bool isActive = true;

    public bool getActive()
    {
        return isActive;
    }

	// Use this for initialization
	void Start () {
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
                TurnManager turnManager = FindObjectOfType<TurnManager>();
                turnManager.startComputerTurn();
            }
        }
    }
}
