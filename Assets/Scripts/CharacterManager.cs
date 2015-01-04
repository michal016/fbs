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
	}
	
	// Update is called once per frame
	void Update () {

        //// Move selected character left
        //if (Input.GetKey(KeyCode.LeftArrow) == true)
        //{
        //    Vector3 pos = inCharacters[selected].transform.localPosition;
        //    Vector3 scale = inCharacters[selected].transform.localScale;
            
        //    scale.x = -1f;
        //    pos.x -= inSpeed;
        //    animator.SetInteger("state", 1);

        //    inCharacters[selected].transform.localPosition = pos;
        //    inCharacters[selected].transform.localScale = scale;
        //}

        //// Move selected character right
        //if (Input.GetKey(KeyCode.RightArrow) == true)
        //{
        //    Vector3 pos = inCharacters[selected].transform.localPosition;
        //    Vector3 scale = inCharacters[selected].transform.localScale;

        //    scale.x = 1f;
        //    pos.x += inSpeed;
        //    animator.SetInteger("state", 1);

        //    inCharacters[selected].transform.localPosition = pos;
        //    inCharacters[selected].transform.localScale = scale;
        //}

        //// Finish move animation
        //if (Input.GetKeyUp(KeyCode.RightArrow) == true || Input.GetKeyUp(KeyCode.LeftArrow) == true)
        //{
        //    animator.SetInteger("state", 0);
        //}

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
        }
	}

    void showArrow(int selected)
    {

        // Show arrow over selected character
        GameObject selectedCharacter = inCharacters[selected];
        GameObject arrow = selectedCharacter.transform.Find("arrow").gameObject;
        arrow.renderer.enabled = true;

        CharacterMove characterMove = (CharacterMove)selectedCharacter.GetComponent("CharacterMove");
        characterMove.setActive(true);

        // Make sight active
        Transform selectedSightTransform = inCharacters[selected].transform.Find("sight");
        Sight selectedSight = (Sight)selectedSightTransform.GetComponent("Sight");
        selectedSight.setActive(true);

        // Remember new animator
        animator = inCharacters[selected].GetComponent<Animator>();
    }

    void hideArrow(int selected)
    {
        // Hide arrow over selected character
        GameObject selectedCharacter = inCharacters[selected];
        GameObject arrow = selectedCharacter.transform.Find("arrow").gameObject;
        arrow.renderer.enabled = false;

        CharacterMove characterMove = (CharacterMove)selectedCharacter.GetComponent("CharacterMove");
        characterMove.setActive(false);

        // Make sight not active
        Transform selectedSightTransform = inCharacters[selected].transform.Find("sight");
        Sight selectedSight = (Sight)selectedSightTransform.GetComponent("Sight");
        selectedSight.setActive(false);
    }
}
