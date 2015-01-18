using UnityEngine;
using System.Collections;

public class LevelStarsRenderer : MonoBehaviour {

    public int inLevel;

    private GameObject star1;
    private GameObject star2;
    private GameObject star3;

    private GameObject star_whiteblack1;
    private GameObject star_whiteblack2;
    private GameObject star_whiteblack3;

	// Use this for initialization
	void Start () {

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

        showStars();
	}

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
	
	// Update is called once per frame
	void Update () {
	
	}
}
