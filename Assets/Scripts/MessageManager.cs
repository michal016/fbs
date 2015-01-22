using UnityEngine;
using System.Collections;

public class MessageManager : MonoBehaviour {

    private GameObject your_turn;
    private GameObject enemy_turn;
    private GameObject you_win;
    private GameObject you_lost;
    private GameObject target;
    private GameObject arrow;

    private GameObject star1;
    private GameObject star2;
    private GameObject star3;

    private GameObject star_whiteblack1;
    private GameObject star_whiteblack2;
    private GameObject star_whiteblack3;

    private ArrayList activeMessages;

	// Use this for initialization
    void Start()
    {
        your_turn = transform.Find("your_turn").gameObject;
        enemy_turn = transform.Find("enemy_turn").gameObject;
        you_win = transform.Find("you_win").gameObject;
        you_lost = transform.Find("you_lost").gameObject;
        target = transform.Find("target").gameObject;
        arrow = transform.Find("arrow").gameObject;

        star1 = transform.Find("star1").gameObject;
        star2 = transform.Find("star2").gameObject;
        star3 = transform.Find("star3").gameObject;

        star_whiteblack1 = transform.Find("star_whiteblack1").gameObject;
        star_whiteblack2 = transform.Find("star_whiteblack2").gameObject;
        star_whiteblack3 = transform.Find("star_whiteblack3").gameObject;

        your_turn.renderer.enabled = false;
        enemy_turn.renderer.enabled = false;
        you_win.renderer.enabled = false;
        you_lost.renderer.enabled = false;

        star1.renderer.enabled = false;
        star2.renderer.enabled = false;
        star3.renderer.enabled = false;

        star_whiteblack1.renderer.enabled = false;
        star_whiteblack2.renderer.enabled = false;
        star_whiteblack3.renderer.enabled = false;

        activeMessages = new ArrayList();

        Invoke("hideTargetMsg", 2.0f);
    }

    public void hideTargetMsg()
    {
        target.renderer.enabled = false;
        arrow.renderer.enabled = false;
    }

    public void playerTurnMsg()
    {
        if (!you_lost.renderer.enabled)
        {
            showMessage(your_turn);
            Invoke("HideAllMessages", 2.0f);
        }
    }

    public void enemyTurnMsg()
    {
        if (!you_lost.renderer.enabled)
        {
            showMessage(enemy_turn);
            Invoke("HideAllMessages", 2.0f);
        }
    }

    public void youWinMsg(int stars)
    {
        HideAllMessages();
        showMessage(you_win);

        Invoke("showWhiteBlackStars", 1.0f);

        if (stars > 0)
        {
            // show the first star
            Invoke("showStar1", 2.0f);

            //star1.renderer.enabled = true;

            if (stars > 1)
            {
                // show ths second star
                Invoke("showStar2", 2.5f);

                if (stars > 2)
                {
                    // show the thir star
                    Invoke("showStar3", 3.0f);
                }
            }
        }
    }

    private void showWhiteBlackStars()
    {
        star_whiteblack1.renderer.enabled = true;
        star_whiteblack2.renderer.enabled = true;
        star_whiteblack3.renderer.enabled = true;
    }

    private void showStar1()
    {
        star1.renderer.enabled = true;
    }

    private void showStar2()
    {
        star2.renderer.enabled = true;
    }

    private void showStar3()
    {
        star3.renderer.enabled = true;
    }

    public void youLostMsg()
    {
        HideAllMessages();
        you_lost.renderer.enabled = true;
    }

    private void showMessage(GameObject message)
    {
        HideAllMessages();
        message.renderer.enabled = true;
        activeMessages.Add(message);
    }

    private void HideAllMessages()
    {
        foreach (GameObject message in activeMessages)
        {
            message.renderer.enabled = false;
        }

        activeMessages.Clear();
    }
}
