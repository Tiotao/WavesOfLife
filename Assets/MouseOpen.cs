using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOpen : MonoBehaviour {

	SpriteRenderer sr;

	void Start() {
		sr = gameObject.GetComponent<SpriteRenderer>();
		sr.enabled = false;
	}

	// Use this for initialization
	void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Player")) {
			sr.enabled = true;
		}
	}

	void OnTriggerExit(Collider other) {
		if(other.CompareTag("Player")) {
			sr.enabled = false;
		}
	}
}
