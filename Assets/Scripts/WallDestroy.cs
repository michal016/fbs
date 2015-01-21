using UnityEngine;
using System.Collections;

public class WallDestroy : MonoBehaviour
{

    private int destroylevel = 0;
    private SpriteRenderer spriteRenderer;

    public GameObject inBricks;
    public Sprite inStoneCrack;
    public Sprite inStoneCrack2;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void hit()
    {
        destroylevel++;

        if (destroylevel == 1)
        {
            spriteRenderer.sprite = inStoneCrack;
        }
        else if (destroylevel == 0)
        {
            spriteRenderer.sprite = inStoneCrack2;
        }
        else if (destroylevel == 2)
        {
            Instantiate(inBricks, transform.position, transform.rotation);
            DestroyObject(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            destroylevel = 2;
            hit();
        }
    }
}
