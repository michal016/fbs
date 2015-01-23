using UnityEngine;
using System.Collections;

public class GearBox : MonoBehaviour {

    public GameObject inFirePrefab;

    void OnCollisionEnter2D(Collision2D collision)
    {
        // On collision with fireing arrow
        if (collision.gameObject.tag == "fireBullet")
        {
            DestroyObject(collision.collider.GetComponent<Rigidbody2D>());

            // Make fire bigger
            Wheel wheel = FindObjectOfType<Wheel>();
            GameObject fire = wheel.transform.FindChild("fire").gameObject;
            ParticleSystem particle = fire.GetComponent<ParticleSystem>();
            particle.startSize = 0.9f;

            fire = wheel.transform.FindChild("fire2").gameObject;
            particle = fire.GetComponent<ParticleSystem>();
            particle.startSize = 0.5f;

            // Destroy wheel
            wheel.destroy();
        }
    }
}
