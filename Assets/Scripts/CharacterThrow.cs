using UnityEngine;
using System.Collections;

public class CharacterThrow : MonoBehaviour
{

    public GameObject inBulletPrefab;
    public float inBulletForce = 5.0f;

    private bool thrownig = false;
    private int forceTime = 0;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            thrownig = true;
        }

        if (thrownig)
        {
            forceTime++;
        }


        if (thrownig && Input.GetKeyUp(KeyCode.Space) == true)
        {
            if (forceTime > 0)
            {
                Throw(forceTime);
                forceTime = 0;
                thrownig = false;
            }
            
        }

        if (forceTime > 20)
        {
            Throw(forceTime);
            forceTime = 0;
            thrownig = false;
        }


    }

    void Throw(int time)
    {
        Vector3 force = new Vector3(5f, 5f, 0f);
        Vector3 pos = transform.position;
        pos.y += 0.2f;

        GameObject newBullet = Instantiate(inBulletPrefab, pos, transform.rotation) as GameObject;
        Rigidbody2D bulletRB = newBullet.GetComponent<Rigidbody2D>();
        bulletRB.AddForce(force * inBulletForce * time);
    }
}
