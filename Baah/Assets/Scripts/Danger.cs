using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Danger : MonoBehaviour {

    public float speed = 10;
    public float distance = -70;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position -= Vector3.forward * speed * Time.deltaTime;
	}

    private void LateUpdate()
    {
        if (transform.localPosition.z <= distance)
        {
            Destroy(gameObject);
        }
    }
}
