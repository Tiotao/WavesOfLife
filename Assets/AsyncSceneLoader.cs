﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AsyncSceneLoader : MonoBehaviour {

    AsyncOperation a;

    // Use this for initialization
    void Start () {
        a = SceneManager.LoadSceneAsync("Lvl1");
        a.allowSceneActivation = false;
        
    }
	
	// Update is called once per frame
	void Update () {
    }

    public void ToNextScene()
    {
        a.allowSceneActivation = true;
    }
}
