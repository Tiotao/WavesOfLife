using UnityEngine;
using System.Collections;

public class FlowBugsMove : MonoBehaviour {
    public float Speed;
    public bool BeginMove;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(BeginMove)
        this.transform.Translate(new Vector3(0, -1, 0) * Speed * Time.deltaTime * 60f);
    }
}
