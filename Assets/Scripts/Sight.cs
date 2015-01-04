using UnityEngine;
using System.Collections;

public class Sight : MonoBehaviour
{
    public GameObject inBulletPrefab;
    public GameObject inStrengthIndicator;
    public float inBulletForce = 35.0f;

    private bool thrownig = false;
    private int forceTime = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) == true)
        {
            //if (transform.rotation.z < 0.45f)
            {
                transform.Rotate(new Vector3(0, 0, 1f));
            }
        }

        if (Input.GetKey(KeyCode.DownArrow) == true)
        {
            //if (transform.rotation.z > 0.0f)
            {
                transform.Rotate(new Vector3(0, 0, -1f));
            }
        }


        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            thrownig = true;
            inStrengthIndicator.transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (thrownig)
        {
            forceTime++;
            inStrengthIndicator.transform.localScale = new Vector3(forceTime/21f, 1f, 1f);
        }


        if (thrownig && Input.GetKeyUp(KeyCode.Space) == true)
        {
            if (forceTime > 0)
            {
                Throw(forceTime);
                forceTime = 0;
                thrownig = false;
                inStrengthIndicator.transform.localScale = new Vector3(0f, 1f, 1f);
            }

        }

        if (forceTime > 20)
        {
            Throw(forceTime);
            forceTime = 0;
            thrownig = false;
            inStrengthIndicator.transform.localScale = new Vector3(0f, 1f, 1f);
        }

    }

    void Throw(int time)
    {
        Vector3 pos = transform.position;
        pos.y += 0.3f;

        GameObject newBullet = Instantiate(inBulletPrefab, pos, transform.rotation) as GameObject;
        Rigidbody2D bulletRB = newBullet.GetComponent<Rigidbody2D>();
        bulletRB.AddForce(transform.right * inBulletForce * time);
        bulletRB.AddTorque(-4.0f);
    }
}
