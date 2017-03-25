using UnityEngine;
using System.Collections;

public class BigFishTrigger : MonoBehaviour {
    public GameObject bigfish;
    AudioSource _audio;
	// Use this for initialization
	void Start () {
        _audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            bigfish.GetComponent<FishFlowBy>().Flow = true;
            if (!_audio.isPlaying) {
                _audio.Play();
            }
        }
    }
}
