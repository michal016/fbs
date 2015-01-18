using UnityEngine;
using System.Collections;

public class WallDestroy : MonoBehaviour {

    private int destroylevel = 0;
    private SpriteRenderer spriteRenderer;

    public GameObject inBrick;
    public GameObject inBrickSmall;
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
        else if (destroylevel == 2)
        {
            spriteRenderer.sprite = inStoneCrack2;
        }
        else if (destroylevel == 3)
        {
            Vector3 pos = transform.position;
            pos.x -= 0.3f;

            for (int i = 0; i < 20; i++)
            {
                pos.x += 0.01f;
                pos.y += 0.01f; 
                Instantiate(inBrick, pos, transform.rotation);
            }
            for (int i = 0; i < 20; i++)
            {
                pos.x += 0.01f;
                pos.y += 0.01f; 
                Instantiate(inBrickSmall, pos, transform.rotation);
            }

            DestroyObject(gameObject);
        }
    }
}
