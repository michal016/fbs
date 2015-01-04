using UnityEngine;
using System.Collections;

public class Gate : MonoBehaviour {

    private bool opened = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        if (transform.rotation.z < 0.7f)
        {
            transform.Rotate(new Vector3(0f, 0f, 0.3f));
        }

        if (transform.rotation.z > 0f)
        {
            transform.Rotate(new Vector3(0f, 0f, -0.3f));
        }

	}
}
