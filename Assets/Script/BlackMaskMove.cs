using UnityEngine;
using System.Collections;

public class BlackMaskMove : MonoBehaviour {
    public float Speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.gameObject.transform.Translate(new Vector3(0, 1, 0) * Speed * Time.deltaTime * 60f);
    }
}
