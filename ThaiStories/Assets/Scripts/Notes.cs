﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notes : MonoBehaviour {

    Rigidbody2D rb;
    public float speed;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start () {
        rb.velocity = new Vector2(0, -speed);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
