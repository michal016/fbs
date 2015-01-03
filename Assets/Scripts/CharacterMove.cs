using UnityEngine;
using System.Collections;

public class CharacterMove : MonoBehaviour
{

    Animator animator;

    public float inSpeed = 0.05f;

    // Use this for initialization
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.localPosition;
        Vector3 scale = transform.localScale;

        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            if (pos.x > -9f)
            {
                scale.x = -0.5f;
                pos.x -= inSpeed;
                animator.SetInteger("state", 1);
            }
        }

        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            if (pos.x < 6.8f)
            {
                scale.x = 0.5f;
                pos.x += inSpeed;
                animator.SetInteger("state", 1);
            }
        }


        //if (Input.GetKeyDown(KeyCode.RightArrow) == true)
        //{
        //    animator.SetInteger("state", 1);
        //}

        //if (Input.GetKeyDown(KeyCode.LeftArrow) == true)
        //{
        //    animator.SetInteger("state", 1);
        //}


        if (Input.GetKeyUp(KeyCode.RightArrow) == true || Input.GetKeyUp(KeyCode.LeftArrow) == true)
        {
            animator.SetInteger("state", 0);
        }

        transform.localPosition = pos;
        transform.localScale = scale;
    }
}
