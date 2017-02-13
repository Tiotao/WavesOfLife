using UnityEngine;
using System.Collections;

public class lvl1End : MonoBehaviour {
    public GameObject _player;
    public GameObject finalFish;
    public GameObject Jelly;
	// Use this for initialization
	void Start () {
        iTween.FadeTo(finalFish, 0f, 0f);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            _player.GetComponent<AutoMove>().lvl1End = true;
            iTween.FadeTo(finalFish, 1f, 0.5f);
            finalFish.GetComponent<PlayAniDeadFish>().startplay = true;
            iTween.FadeTo(Jelly.transform.Find("GlowPointSprite").gameObject, 0f, 0.5f);
            // Jelly.SetActive(false);
            finalFish.tag = "WALL";
        }
    }
}
