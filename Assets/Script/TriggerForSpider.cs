using UnityEngine;
using System.Collections;

public class TriggerForSpider : MonoBehaviour {
    public GameObject Spider;
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
            Spider.GetComponent<Animator>().SetTrigger("TrigSpider");
        }
    }
}
