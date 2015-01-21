using UnityEngine;
using System.Collections;

public class GearBox : MonoBehaviour {

    public GameObject inFirePrefab;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "fireBullet")
        {
            //GameObject fire = collision.collider.transform.FindChild("fire").gameObject;
            //GameObject fire = transform.Find("gearFire").gameObject;

            //ParticleSystem particle = fire.GetComponent<ParticleSystem>();

            //particle.startSize = 3.0f;


            DestroyObject(collision.collider.GetComponent<Rigidbody2D>());

            Wheel wheel = FindObjectOfType<Wheel>();

            GameObject fire = wheel.transform.FindChild("fire").gameObject;
            ParticleSystem particle = fire.GetComponent<ParticleSystem>();
            particle.startSize = 0.9f;

            fire = wheel.transform.FindChild("fire2").gameObject;
            particle = fire.GetComponent<ParticleSystem>();
            particle.startSize = 0.5f;

            wheel.destroy();
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
