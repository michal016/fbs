using UnityEngine;
using System.Collections;

public class Wheel : MonoBehaviour {

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            //animator.SetInteger("state", 1);

            //BoxCollider2D wheelCollider = GetComponent<BoxCollider2D>();
            //wheelCollider.size = new Vector2(0.69f, 0.3f);
            //Vector2 center = wheelCollider.center;
            //center.y -= 0.15f;
            //wheelCollider.center = center;
        }
    }
}
