using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimation : MonoBehaviour {
    public GameObject TreeAni;
    public bool ifset = false;
    public GameObject EndTrigger;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(this.GetComponent<SpritesAnimation>().FinishAni&&!ifset)
        {
            TreeAni.GetComponent<SpritesAnimation>().Begin = -1;
            ifset = true;
        }
	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            this.GetComponent<SpritesAnimation>().Begin = -1;
            EndTrigger.GetComponent<EndAnimationlvl2>().automove = false;
        }
    }
}
