using UnityEngine;
using System.Collections;

// Class used to choice character to play
public class CharacterManager : MonoBehaviour {

    Animator animator;
    public float inSpeed = 0.05f;
    public GameObject[] inCharacters;
    private bool isActive = false;
    private int selected = 0;

    // Activates player's move
    public void setActive(bool active)
    {
        isActive = active;

        if (active)
        {
            showArrow(selected);
        }
        else
        {
            hideAllArrows();
        }
    }

	// Use this for initialization
	void Start () {

        // Show arrow only over first character
        hideAllArrows();
        //showArrow(selected);
	}
	
	// Update is called once per frame
	void Update () {

        if (isActive)
        {

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
	}

    // Shows arrow over character and makes it active
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

    // Hides arrow over character and locks his moves
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

    // Hides all arrows and locks all characters' moves
    void hideAllArrows()
    {
        // Hide all arrows
        for (int i = 0; i < inCharacters.Length; i++)
        {
            hideArrow(i);
        }
    }
}
