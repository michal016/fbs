using UnityEngine;
using System.Collections;

public class StoneParticle : MonoBehaviour {

    public GameObject inStoneParticlePrefab;
    private bool isActive = true;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "castle")
        {
            if (isActive)
            {
                GameObject newBullet = Instantiate(inStoneParticlePrefab, transform.position, transform.rotation) as GameObject;
                

                DestroyObject(gameObject);


                collision.collider.GetComponent<WallDestroy>().hit();
            }
        }
        isActive = false;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
