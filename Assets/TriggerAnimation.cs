using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimation : MonoBehaviour {
    public GameObject TreeAni;
    public bool ifset = false;
    public GameObject EndTrigger;

    public bool _isCoreFading = false;

    public GameObject _player;

    private SpriteRenderer _core;

    private float _coreAlpha = 1f;

    AsyncSceneLoader _async;
	// Use this for initialization
	void Start () {
		_async = GameObject.FindObjectOfType<AsyncSceneLoader>();
	}
	
	// Update is called once per frame
	void Update () {
        
        if (_isCoreFading && _core) {
            if (_coreAlpha > 0) {
                _coreAlpha =  _coreAlpha - Time.deltaTime;
                _core.color = new Color(_core.color.r, _core.color.g, _core.color.b, _coreAlpha);
            }
            
        }

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
            FadePlayer();
        }
    }

    private void FadePlayer() {
        Transform flower = _player.transform.GetChild(0);
        flower.GetChild(2).GetComponent<ParticleSystem>().enableEmission = false;
        flower.GetChild(3).GetComponent<ParticleSystem>().enableEmission = false;
        _core = flower.GetChild(1).GetComponent<SpriteRenderer>();
        _isCoreFading = true;
    }
}
