using UnityEngine;
using System.Collections;

public class Wheel : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "gameOver")
        {
            // Game over
            TurnManager turnManager = FindObjectOfType<TurnManager>();
            turnManager.gameOver();
        }
    }
}
