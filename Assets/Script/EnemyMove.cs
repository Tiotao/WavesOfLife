using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {
	public float Range;
	public bool Horizental;
	public bool Vertical;
	public float time;
	private Vector3 origin,destination;
	private Vector3 vel=Vector3.zero;
	public bool come, back;
	// Use this for initialization
	void Start () {
		come = true;
		origin = this.transform.position;
		destination = this.transform.position;
		if (Horizental) {
			destination.x += Range;
		} else {
			destination.y += Range;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (come) {
			transform.position = Vector3.SmoothDamp (transform.position, destination, ref vel, time);
			if (Vector3.Magnitude( transform.position - destination)<0.05f) {
				come = false;
				back = true;
			}
		}
		if (back) {
			transform.position = Vector3.SmoothDamp (transform.position, origin, ref vel, time);
			if (Vector3.Magnitude(transform.position - origin)<0.05f) {
				come = true;
				back = false;
			}
		}
			}
}
