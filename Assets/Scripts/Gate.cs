using UnityEngine;
using System.Collections;

public class Gate : MonoBehaviour {

    private bool openingGate = false;
    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

        if (openingGate)
        {
            if (transform.rotation.z < 0.7f)
            {
                transform.Rotate(new Vector3(0f, 0f, 0.3f));
            }
            else
            {
                audioSource.Stop();
                openingGate = false;
            }
        }

	}

    public void open()
    {
        openingGate = true;
        audioSource.Play();
    }
}
