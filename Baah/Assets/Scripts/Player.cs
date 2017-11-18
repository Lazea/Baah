using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    float h;
    float v;

    public float horizontalRange = 2.5f;
    public float verticalRange = 2f;
    float verticalOffset;

    public Transform herd;

    Vector3 position;

    // Use this for initialization
    void Start () {
        verticalOffset = transform.position.z;
    }
	
	// Update is called once per frame
	void Update () {
        // Input
        // TODO: Switch to finger gestures
        float width = Screen.width;
        h = Input.mousePosition.x;
        h = h - width * 0.5f;
        h /= Screen.width;
        h = Mathf.Clamp(h, -0.5f, 0.5f);

        v = (Mathf.Cos(h) - 1f) * -1;

        // Apply motion
        float x = h * 2f * horizontalRange;
        float z = verticalOffset + v * verticalRange;
        position = new Vector3(x, transform.position.y, z);
        transform.position = position;

        // Edit herd position
        herd.localPosition = new Vector3(-x, herd.position.y, herd.position.z);
    }
}
