using UnityEngine;
using System.Collections;

public class StrengthIndicator : MonoBehaviour {

    private Quaternion rotation;

    // Remember rotation
    void Awake()
    {
        rotation = transform.rotation;
    }

    // Change rotation to the first state
    void LateUpdate()
    {
        transform.rotation = rotation;
    }

    void Update()
    {
        transform.rotation = Quaternion.identity;
        transform.localPosition = new Vector3(-0.257f, 0.42f, 0f);
    }
}
