using UnityEngine;
using System.Collections;

public class ZoomInTrigger : MonoBehaviour {
    public float zoomAmount;
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
            this.GetComponent<Zoomin>().Zoom_in(zoomAmount);
        }
    }
}
