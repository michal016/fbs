﻿using UnityEngine;
using System.Collections;

public class Sight : MonoBehaviour
{
    public GameObject inBulletPrefab;
    public GameObject inStrengthIndicator;
    public float inBulletForce = 20.0f;

    private bool isActive = false;
    private bool thrownig = false;
    private int forceTime = 0;

    public void setActive(bool active)
    {
        isActive = active;

        renderer.enabled = active;
    }

    // Use this for initialization
    void Start()
    {
        inStrengthIndicator.renderer.enabled = false;
        renderer.enabled = isActive;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
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
                inStrengthIndicator.renderer.enabled = true;
                inStrengthIndicator.transform.localScale = new Vector3(0f, 1f, 1f);
            }

            if (thrownig)
            {
                forceTime++;
                inStrengthIndicator.transform.localScale = new Vector3(forceTime / 41f, 1f, 1f);
            }


            if (thrownig && Input.GetKeyUp(KeyCode.Space) == true)
            {
                if (forceTime > 0)
                {
                    Throw(forceTime);
                    forceTime = 0;
                    thrownig = false;
                    inStrengthIndicator.renderer.enabled = false;
                }

            }

            if (forceTime > 40)
            {
                Throw(forceTime);
                forceTime = 0;
                thrownig = false;
                inStrengthIndicator.renderer.enabled = false;
            }
        }
    }

    void Throw(int time)
    {
        float torque = -0.6f;
        Vector2 force = transform.right;
        Vector3 pos = transform.position;
        pos.y += 0.3f;

        CharacterMove characterMove = this.GetComponentInParent<CharacterMove>();
        Quaternion rotation = transform.rotation;

        // If character turned left
        if (characterMove.transform.localScale.x < 0)
        {
            rotation = Quaternion.AngleAxis(180.0f, Vector3.up) * rotation;
            force.x = -force.x;
        }

        GameObject newBullet = Instantiate(inBulletPrefab, pos, rotation) as GameObject;
        Rigidbody2D bulletRB = newBullet.GetComponent<Rigidbody2D>();

        bulletRB.AddTorque(torque);
        bulletRB.AddForce(force * inBulletForce * time);

        // End user turn
        TurnManager turnManager = this.GetComponentInParent<TurnManager>();
        turnManager.setTurn(1);
    }
}
