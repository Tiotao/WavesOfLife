using UnityEngine;
using System.Collections;

public class End : MonoBehaviour {
	public GameObject _player;
	public GameObject _Egg;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider col)
	{
		if (col.CompareTag ("Player")) {
			_player.transform.LookAt (_Egg.transform.position);
			_player.GetComponent<AutoMove> ().END = true;
		}
	}
}
