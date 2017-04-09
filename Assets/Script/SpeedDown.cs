using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedDown : MonoBehaviour {
    public GameObject[] BugGenerators;
    public GameObject[] Bugs;
    public GameObject BGanimation;
    public GameObject SnakeAnimation;
    public GameObject picture;
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
            picture.GetComponent<SpriteRenderer>().enabled = false;
            for (int i = 0; i < BugGenerators.Length; i++)
            {
                BugGenerators[i].GetComponent<BugGenerator>().StopTime = true;
            }

           Bugs = GameObject.FindGameObjectsWithTag("BUGS");
            for (int i = 0; i < Bugs.Length; i++)
            {
                Bugs[i].GetComponent<BugsAutoMove>().Speed = 0.008f;
            }
            BGanimation.GetComponent<SpritesAnimation>().Begin = 100f;
            SnakeAnimation.GetComponent<SpritesAnimation>().Begin = 100f;
            Invoke("TimeContinue",8.0f);
        }
    }

    private void TimeContinue()
    {
        for (int i = 0; i < BugGenerators.Length; i++)
        {
            BugGenerators[i].GetComponent<BugGenerator>().StopTime = false;
        }
        BGanimation.GetComponent<SpritesAnimation>().Begin = -1;
        SnakeAnimation.GetComponent<SpritesAnimation>().Begin = -1;
        this.GetComponentInChildren<Zoomin>().Zoom_out(7f);
    }

}
