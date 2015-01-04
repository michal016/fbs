using UnityEngine;
using System.Collections;

public class CharacterManager : MonoBehaviour {

    Animator animator;

    public float inSpeed = 0.05f;

    public GameObject[] inCharacters;

    private int selected = 0;

	// Use this for initialization
	void Start () {

        // Hide all arrows
        foreach (GameObject character in inCharacters)
        {
            GameObject arrow = character.transform.Find("arrow").gameObject;
            arrow.renderer.enabled = false;
        }
        // Show arrow over first character
        showArrow(selected);

        // Set animator of first character
        animator = inCharacters[selected].GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        // Move selected character left
        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            Vector3 pos = inCharacters[selected].transform.localPosition;
            Vector3 scale = inCharacters[selected].transform.localScale;
            
            scale.x = -1f;
            pos.x -= inSpeed;
            animator.SetInteger("state", 1);

            inCharacters[selected].transform.localPosition = pos;
            inCharacters[selected].transform.localScale = scale;
        }

        // Move selected character right
        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            Vector3 pos = inCharacters[selected].transform.localPosition;
            Vector3 scale = inCharacters[selected].transform.localScale;

            scale.x = 1f;
            pos.x += inSpeed;
            animator.SetInteger("state", 1);

            inCharacters[selected].transform.localPosition = pos;
            inCharacters[selected].transform.localScale = scale;
        }

        // Finish move animation
        if (Input.GetKeyUp(KeyCode.RightArrow) == true || Input.GetKeyUp(KeyCode.LeftArrow) == true)
        {
            animator.SetInteger("state", 0);
        }

        // Change selected character
        if (Input.GetKeyDown(KeyCode.Tab) == true)
        {
            // Stop animation
            animator.SetInteger("state", 0);
            
            hideArrow(selected);
            if (++selected > inCharacters.Length - 1)
            {
                selected = 0;
            }
            showArrow(selected);
            
            // Remember new animator
            animator = inCharacters[selected].GetComponent<Animator>();
        }
	}

    // Show arrow over selected character
    void showArrow(int selected)
    {
        GameObject selectedCharacter = inCharacters[selected];
        GameObject arrow = selectedCharacter.transform.Find("arrow").gameObject;
        arrow.renderer.enabled = true;
    }

    // Hide arrow over selected character
    void hideArrow(int selected)
    {
        GameObject selectedCharacter = inCharacters[selected];
        GameObject arrow = selectedCharacter.transform.Find("arrow").gameObject;
        arrow.renderer.enabled = false;
    }
}
