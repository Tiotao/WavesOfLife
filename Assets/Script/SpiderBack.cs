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
                if (!GameObject.FindGameObjectWithTag("Player").GetComponent<AutoMove>().HasSpeedUp)
                {
                    Spider.GetComponent<Animator>().SetTrigger("TrigSpider");
                    Spider.GetComponent<SpiderStatus>().IsActive = true;
                    if (!this.GetComponent<AudioSource>().isPlaying)
                        this.GetComponent<AudioSource>().Play();
                }
                else
                {
                    Invoke("triggerAnimation", 1.0f);
                }
            }
        }
    }
    private void triggerAnimation()
    {
        
        Spider.GetComponent<Animator>().SetTrigger("TrigSpider");
        Spider.GetComponent<SpiderStatus>().IsActive = true;
    }
}
