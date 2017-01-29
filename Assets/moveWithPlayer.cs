using UnityEngine;
using System.Collections;

public class moveWithPlayer : MonoBehaviour {
    public GameObject _Player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
        this.transform.position = _Player.transform.position;
	}
}
