using UnityEngine;
using System.Collections;

public class TriggerEnemyFish : MonoBehaviour {
    public GameObject EnemyFish;
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
            EnemyFish.SetActive(true);
          //  EnemyFish.GetComponentInChildren<SpriteRenderer>().enabled = true;
            EnemyFish.GetComponent<Animator>().SetTrigger("Play");
        }
    }
}
