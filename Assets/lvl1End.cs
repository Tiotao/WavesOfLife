using UnityEngine;
using System.Collections;

public class lvl1End : MonoBehaviour {
    public GameObject _player;
    public GameObject finalFish;
    public GameObject Jelly;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            _player.GetComponent<AutoMove>().lvl1End = true;
            finalFish.GetComponent<PlayAniDeadFish>().startplay = true;
            Jelly.SetActive(false);
            finalFish.tag = "WALL";
        }
    }
}
