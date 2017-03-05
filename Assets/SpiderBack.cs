using UnityEngine;
using System.Collections;

public class SpiderBack : MonoBehaviour {
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
            if (Spider.GetComponent<SpiderStatus>().IsActive)
            {
                Spider.GetComponent<Animator>().SetTrigger("SpiderBack");
                Spider.GetComponent<SpiderStatus>().IsActive = false;
            }
            else
            {
                Spider.GetComponent<Animator>().SetTrigger("TrigSpider");
                Spider.GetComponent<SpiderStatus>().IsActive = true;
            }
        }
    }
}
