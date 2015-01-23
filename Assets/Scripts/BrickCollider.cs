using UnityEngine;
using System.Collections;

public class BrickCollider : MonoBehaviour {

    public GameObject inBrokenDeck;
    private TurnManager turnManager;

	// Use this for initialization
    void Start()
    {
        turnManager = FindObjectOfType<TurnManager>();
    }
	

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Detect collision with brick and create brocken deck
        if (collision.collider.tag == "brick")
        {
            DestroyObject(transform.parent.gameObject);
            Instantiate(inBrokenDeck, new Vector3(4.575f, -0.818f, 0), transform.rotation);
        }
    }
	
}
