using UnityEngine;
using System.Collections;

public class Wheel : MonoBehaviour {

    public GameObject inGate;
    private bool openingGate = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            openingGate = true;
        }
    }
	
	// Update is called once per frame
	void Update () {

        if (openingGate)
        {
            if (inGate.transform.rotation.z < 0.7f)
            {
                inGate.transform.Rotate(new Vector3(0f, 0f, 0.3f));
            }
            else
            {
                openingGate = false;
            }
        }
	}
}
