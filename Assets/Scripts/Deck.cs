using UnityEngine;
using System.Collections;

public class Deck : MonoBehaviour
{

    private bool closingDeck = false;
    private AudioSource audioSource;

	// Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();	
	}
	
	// Update is called once per frame
	void Update () {

        // If closing the deck
        if (closingDeck)
        {
            if (transform.rotation.z > -0.7f)
            {
                transform.Rotate(new Vector3(0f, 0f, -0.3f));
            }
            else
            {
                // After closing - stop sound playing
                audioSource.Stop();
                closingDeck = false;
            }
        }
	}

    // Close the deck
    public void close()
    {
        closingDeck = true;
        audioSource.Play();
    }
}
