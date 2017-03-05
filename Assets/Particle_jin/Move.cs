using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

    public float speed = 0.5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
      

        transform.position = new Vector3(0f, 0f + Time.time * speed, 0f);
	}


}
