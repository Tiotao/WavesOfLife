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
    public GameObject[] FlowBugs;

    public FadeInWhenBeginning _BlackOverlay;

    bool _startFading = false;
	// Use this for initialization
	void Start () {
        _Map.SetActive(false);
        Light.GetComponent<SpritesAnimation>().Begin = 0f;
        Mask.SetActive(true);
        Glow.SetActive(true);
        for(int i=0;i<FlowBugs.Length;i++)
        {
            FlowBugs[i].GetComponent<FlowBugsMove>().BeginMove = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
        timer +=Time.deltaTime;
        if(timer>=_Time)
        {
            if (!_startFading) {
                _startFading = true;
                _BlackOverlay.FadeOut(2f, 2f);
            }
            _camera.GetComponent<CameraFollow>().enabled = false;
        }
	}
}
