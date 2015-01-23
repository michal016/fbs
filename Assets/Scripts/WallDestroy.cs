using UnityEngine;
using System.Collections;

public class WallDestroy : MonoBehaviour
{

    private int destroylevel = 0;
    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;

    public GameObject inBricks;
    public Sprite inStoneCrack;
    public Sprite inStoneCrack2;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Destroy the wall
    public void hit()
    {
        destroylevel++;
        audioSource.Play();

        if (destroylevel == 1)
        {
            spriteRenderer.sprite = inStoneCrack;
        }
        else if (destroylevel == 0)
        {
            spriteRenderer.sprite = inStoneCrack2;
        }
        else if (destroylevel >= 2)
        {
            Instantiate(inBricks, transform.position, transform.rotation);
            DestroyObject(gameObject);
        }
    }

    // If collision with bricks and has rigidbody - change to bricks
    void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rigidbody2d = gameObject.GetComponent<Rigidbody2D>();
        if (rigidbody2d != null)
        {
            if (collision.gameObject.tag == "brick")
            {
                destroylevel = 2;
                hit();
            }
        }
    }
}
