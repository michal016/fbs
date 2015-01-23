using UnityEngine;
using System.Collections;

// Used only to change particles' layer (otherwise it is not visible)
public class Fire : MonoBehaviour {

	// Use this for initialization
	void Start () {
        particleSystem.renderer.sortingLayerName = "Foreground";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
