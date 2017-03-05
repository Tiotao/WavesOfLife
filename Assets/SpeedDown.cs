using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedDown : MonoBehaviour {
    public GameObject[] BugGenerators;
    public GameObject[] Bugs;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < BugGenerators.Length; i++)
            {
                BugGenerators[i].GetComponent<BugGenerator>().StopTime = true;
            }

           Bugs = GameObject.FindGameObjectsWithTag("BUGS");
            for (int i = 0; i < Bugs.Length; i++)
            {
                Bugs[i].GetComponent<BugsAutoMove>().TimeStop = true;
            }
            Invoke("TimeContinue",8.0f);
        }
    }

    private void TimeContinue()
    {
        for (int i = 0; i < BugGenerators.Length; i++)
        {
            BugGenerators[i].GetComponent<BugGenerator>().StopTime = false;
        }
        for (int i = 0; i < Bugs.Length; i++)
        {
            Bugs[i].GetComponent<BugsAutoMove>().TimeStop = false;
        }
    }

}
