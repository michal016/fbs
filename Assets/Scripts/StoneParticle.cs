using UnityEngine;
using System.Collections;

public class StoneParticle : MonoBehaviour {

    private AudioSource audioSource;
    private TurnManager turnManager;

    public AudioClip inCastleHitSound;
    public AudioClip inWoodHitSound;

    public GameObject inWoodParticlePrefab;
    public GameObject inStoneParticlePrefab;
    private bool isActive = true;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "castle")
        {
            if (isActive)
            {
                // Play castle_hit sound

                AudioSource castleAudioSource = collision.collider.GetComponent<AudioSource>();

                if (audioSource != null)
                {
                    castleAudioSource.clip = inCastleHitSound;
                    castleAudioSource.Play();
                }

                GameObject newBullet = Instantiate(inStoneParticlePrefab, transform.position, transform.rotation) as GameObject;
                
                DestroyObject(gameObject);

                WallDestroy wallDestroy = collision.collider.GetComponent<WallDestroy>();
                
                // End user turn
                //turnManager.startComputerTurn();
                
                if (wallDestroy != null)
                {
                    wallDestroy.hit();
                }
            }
        }
        else if (collision.gameObject.tag == "wood")
        {
            if (isActive)
            {
                GameObject newBullet = Instantiate(inWoodParticlePrefab, transform.position, transform.rotation) as GameObject;

                // Play castle_hit sound
                audioSource.clip = inWoodHitSound;
                audioSource.Play();
            }
        }
        //else
        //{
        //    // End user turn
        //    turnManager.startComputerTurn();
        //}
        isActive = false;
    }

	// Use this for initialization
	void Start () {
        turnManager = FindObjectOfType<TurnManager>();
        audioSource = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
