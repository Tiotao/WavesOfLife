using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimation : MonoBehaviour {
    public GameObject TreeAni;
    public bool ifset = false;
    public GameObject EndTrigger;

    AsyncSceneLoader _async;
	// Use this for initialization
	void Start () {
		_async = GameObject.FindObjectOfType<AsyncSceneLoader>();
	}
	
	// Update is called once per frame
	void Update () {
		if(this.GetComponent<SpritesAnimation>().FinishAni&&!ifset)
        {
            TreeAni.GetComponent<SpritesAnimation>().Begin = -1;
            ifset = true;
            LevelAccess.SetLevel("2", true);
            _async.ToSelectedScene(3);
            Destroy(this);
        }
	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")|| other.CompareTag("BUGSAVOID"))
        {
            this.GetComponent<SpritesAnimation>().Begin = -1;
            EndTrigger.GetComponent<EndAnimationlvl2>().automove = false;
        }
    }
}
