using UnityEngine;
using System.Collections;

public class SelfRotation : MonoBehaviour {
	private float R;
	public float counter;
	// Use this for initialization
	void Start () {
		R = Random.Range (-10, 10);
		counter = Random.Range (1, 3);
	}
	
	// Update is called once per frame
	void Update () {
		counter -= Time.deltaTime;
		if (counter <= 0) {
			counter = Random.Range (1, 3);
			R = Random.Range (-10, 10);
		}
		this.transform.Rotate (new Vector3(0,0,R)*Time.deltaTime*5);
	}
}
