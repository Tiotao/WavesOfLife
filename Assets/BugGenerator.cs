using UnityEngine;
using System.Collections;

public class BugGenerator : MonoBehaviour {
    public GameObject bug;
    public float RefreshTime;
    private float timer=0f;
    public bool StopTime;
    public float BugsSpeed;
    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void Update() {
     //   this.transform.Translate(Vector3.up*Time.deltaTime);
        if (!StopTime)
        {
            timer += Time.deltaTime;
            if (timer >= RefreshTime)
            {
                GameObject Tbug = GameObject.Instantiate(bug);
                Tbug.transform.eulerAngles = this.transform.eulerAngles;
                Tbug.transform.position = this.transform.position;
                Tbug.transform.parent = this.transform;
                Tbug.GetComponent<BugsAutoMove>().Speed =  BugsSpeed;
                timer = 0;
            }

         }
    }
}
