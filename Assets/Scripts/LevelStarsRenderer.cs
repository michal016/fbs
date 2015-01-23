using UnityEngine;
using System.Collections;

// Renders the stars in menu
public class LevelStarsRenderer : MonoBehaviour {

    public int inLevel;

    private GameObject star1;
    private GameObject star2;
    private GameObject star3;

    private GameObject star_whiteblack1;
    private GameObject star_whiteblack2;
    private GameObject star_whiteblack3;

    private GameObject level2WB;
    private GameObject level3WB;

	// Use this for initialization
	void Start () {

        // Loads saved game from file
        SaveLoad.Load();     

        star1 = transform.Find("star1").gameObject;
        star2 = transform.Find("star2").gameObject;
        star3 = transform.Find("star3").gameObject;

        star_whiteblack1 = transform.Find("star_whiteblack1").gameObject;
        star_whiteblack2 = transform.Find("star_whiteblack2").gameObject;
        star_whiteblack3 = transform.Find("star_whiteblack3").gameObject;

        star1.renderer.enabled = false;
        star2.renderer.enabled = false;
        star3.renderer.enabled = false;

        // If 2nd level - hide w-b graphic
        if (inLevel == 2)
        {
            level2WB = transform.Find("level2wb").gameObject;

            if (GameState.isLevelEnabled(2))
            {
                level2WB.renderer.enabled = false;
            }
        }

        // If 3rd level - hide w-b graphic
        if (inLevel == 3)
        {
            level3WB = transform.Find("level3wb").gameObject;

            if (GameState.isLevelEnabled(3))
            {
                level3WB.renderer.enabled = false;
            }
        }

        showStars();
	}

    // Show number of stars over level button
    public void showStars()
    {
        int stars = GameState.levelStars[inLevel - 1];

        if (stars > 0)
        {
            star1.renderer.enabled = true;
            if (stars > 1)
            {
                star2.renderer.enabled = true;
                if (stars > 2)
                {
                    star3.renderer.enabled = true;
                }
            }
        }
    }
}
