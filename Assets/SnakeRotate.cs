﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeRotate : MonoBehaviour {
    public bool CountDirection;
    public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(!CountDirection)
            this.transform.Rotate(new Vector3(0, 0, 4f * Time.deltaTime* speed));
        else
            this.transform.Rotate(new Vector3(0, 0, -4f * Time.deltaTime* speed));
    }
}
