using UnityEngine;
using System.Collections;

public class Sight : MonoBehaviour
{
    public GameObject inBulletPrefab;
    private GameObject strengthIndicator;
    public float inBulletForce = 10.0f;

    private bool isActive = false;
    private bool thrownig = false;
    private int forceTime = 0;
    private Animator animator;
    private AudioSource audioSource;
    private TurnManager turnManager;
    private CharacterMove characterMove;

    // Set active sight
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
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            // Move sight up
            if (Input.GetKey(KeyCode.UpArrow) == true)
            {
                transform.Rotate(new Vector3(0, 0, 1f));
            }

            // Move sight down
            if (Input.GetKey(KeyCode.DownArrow) == true)
            {
                transform.Rotate(new Vector3(0, 0, -1f));
            }

            // Start shot
            if (Input.GetKeyDown(KeyCode.Space) == true)
            {
                // Start begin to shot animation
                animator.SetInteger("state", 2);

                thrownig = true;
                strengthIndicator.renderer.enabled = true;
                strengthIndicator.transform.localScale = new Vector3(0f, 0.15f, 0.15f);
            }

            // Calculating shot strength
            if (thrownig)
            {
                forceTime++;
                strengthIndicator.transform.localScale = new Vector3(0.15f * forceTime / 101f, 0.15f, 0.15f);
            }

            // Throw the bullet
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

            // Automatic shot
            if (forceTime > 100)
            {
                Throw(forceTime);
                forceTime = 0;
                thrownig = false;
                strengthIndicator.renderer.enabled = false;
            }
        }
    }

    // Start shot
    void Throw(int time)
    {
        // Start shot animation
        animator.SetInteger("state", 3);

        // Play sound
        audioSource.Play();

        // Lock user's moves
        turnManager.lockUserMoves();

        float torque = -0.06f;
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

        // Add force and torque
        bulletRB.AddTorque(torque);
        bulletRB.AddForce(force * inBulletForce * time);


    }
}
