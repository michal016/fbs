using UnityEngine;
using System.Collections;

public class Sight : MonoBehaviour
{
    public GameObject inBulletPrefab;
    private GameObject strengthIndicator;
    public float inBulletForce = 20.0f;

    private bool isActive = false;
    private bool thrownig = false;
    private int forceTime = 0;
    private Animator animator;
    private TurnManager turnManager;
    private CharacterMove characterMove;

    public void setActive(bool active)
    {
        isActive = active;
        renderer.enabled = active;
    }

    // Use this for initialization
    void Start()
    {
        characterMove = this.GetComponentInParent<CharacterMove>();
        turnManager = FindObjectOfType<TurnManager>();
        strengthIndicator = transform.parent.transform.Find("strengthIndicator").gameObject;
        strengthIndicator.renderer.enabled = false;
        renderer.enabled = isActive;
        animator = GetComponentInParent<Animator>();
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
                // Start begin to shot animation
                animator.SetInteger("state", 2);

                thrownig = true;
                strengthIndicator.renderer.enabled = true;
                strengthIndicator.transform.localScale = new Vector3(0f, 0.15f, 0.15f);
            }

            if (thrownig)
            {
                forceTime++;
                strengthIndicator.transform.localScale = new Vector3(0.15f * forceTime / 41f, 0.15f, 0.15f);
            }


            if (thrownig && Input.GetKeyUp(KeyCode.Space) == true)
            {
                if (forceTime > 0)
                {
                    Throw(forceTime);
                    forceTime = 0;
                    thrownig = false;
                    strengthIndicator.renderer.enabled = false;
                }

            }

            if (forceTime > 40)
            {
                Throw(forceTime);
                forceTime = 0;
                thrownig = false;
                strengthIndicator.renderer.enabled = false;
            }
        }
    }

    void Throw(int time)
    {
        // Start shot animation
        animator.SetInteger("state", 3);
        
        // Lock user's moves
        turnManager.lockUserMoves();

        float torque = -0.6f;
        Vector2 force = transform.right;
        Vector3 pos = transform.position;
        pos.y += 0.3f;

        Quaternion rotation = transform.rotation;

        // If character turned left
        if (characterMove.transform.localScale.x < 0)
        {
            rotation = Quaternion.AngleAxis(180.0f, Vector3.up) * rotation;
            force.x = -force.x;
        }

        // Create new bullet
        GameObject newBullet = Instantiate(inBulletPrefab, pos, rotation) as GameObject;
        Rigidbody2D bulletRB = newBullet.GetComponent<Rigidbody2D>();

        bulletRB.AddTorque(torque);
        bulletRB.AddForce(force * inBulletForce * time);


    }
}
