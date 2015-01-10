using UnityEngine;
using System.Collections;

public class MessageManager : MonoBehaviour {

    private GameObject your_turn;
    private GameObject enemy_turn;
    private GameObject you_win;
    private GameObject you_lost;

    private ArrayList activeMessages;

	// Use this for initialization
    void Start()
    {
        your_turn = transform.Find("your_turn").gameObject;
        enemy_turn = transform.Find("enemy_turn").gameObject;
        you_win = transform.Find("you_win").gameObject;
        you_lost = transform.Find("you_lost").gameObject;

        your_turn.renderer.enabled = false;
        enemy_turn.renderer.enabled = false;
        you_win.renderer.enabled = false;
        you_lost.renderer.enabled = false;

        activeMessages = new ArrayList();
    }

    public void playerTurnMsg()
    {
        showMessage(your_turn);
        Invoke("HideAllMessages", 2.0f);
    }

    public void enemyTurnMsg()
    {
        showMessage(enemy_turn);
        Invoke("HideAllMessages", 2.0f);
    }

    public void youWinMsg()
    {
        showMessage(you_win);
    }

    public void youLostMsg()
    {
        HideAllMessages();
        you_lost.renderer.enabled = true;
    }

    private void showMessage(GameObject message)
    {
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
