﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public float speed;

    float score = 0f;

    public Danger danger1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        danger1.speed = speed;
	}
}
