﻿using UnityEngine;
using System.Collections;

public class Lvl1EndingAnimation : MonoBehaviour {
    public GameObject Light;
    public GameObject _camera;
    public float _Time;
    private float timer=0;
    public GameObject _Map;
    public GameObject Mask;
    public GameObject Glow;
	// Use this for initialization
	void Start () {
        _Map.SetActive(false);
        Light.GetComponent<SpritesAnimation>().Begin = 0f;
        Mask.SetActive(true);
        Glow.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
        timer +=Time.deltaTime;
        if(timer>=_Time)
        {
            _camera.GetComponent<CameraFollow>().enabled = false;
        }
	}
}
