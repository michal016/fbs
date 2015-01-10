using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {

    Animator animator;

    private bool movement = false;
    private int movementFrame = 0;

	// Use this for initialization
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        //if (Input.GetKeyDown(KeyCode.A) == true)
        //{
        //    animator.SetInteger("state", 1);
        //    movement = true;
        //}

        if (movement)
        {
            Vector3 position = transform.position;
            position.x += 0.01f;
            transform.position = position;

            if (movementFrame < 100)
            {
                movementFrame++;
            }
            else
            {
                // End movement
                animator.SetInteger("state", 0);
                movementFrame = 0;
                movement = false;


                // Start user turn
                TurnManager turnManager = FindObjectOfType<TurnManager>();
                turnManager.startPlayerTurn();
            }
        }
	}

    public void move()
    {
        animator.SetInteger("state", 1);
        movement = true;
    }
}
