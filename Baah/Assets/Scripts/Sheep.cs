using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour {

    Herd herd;

    public float speed = 10f;
    Vector3 targetOffset;

    // Use this for initialization
    void Start () {
        targetOffset = herd.transform.position - transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        GoToTarget(herd.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        Death();
    }

    void Death()
    {
        // Play death animation

        herd.RemoveSheep();

        Destroy(gameObject);
    }

    public void SetHerd(Herd herd)
    {
        this.herd = herd;
    }

    void GoToTarget(Vector3 target)
    {
        transform.position = target + targetOffset;
    }
}
