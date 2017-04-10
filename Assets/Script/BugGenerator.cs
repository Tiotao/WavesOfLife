using UnityEngine;
using System.Collections;

public class BugGenerator : MonoBehaviour {
    public GameObject bug;
    public float RefreshTime;
    private float timer=0f;
    public bool StopTime;
    public float BugsSpeed;

    public Transform _endingPt;
    public Transform _startingPt;
    public Transform _midwayPt;
    public float MaxRandomRange_x;

    public int _maxInsects;

    

    // Use this for initialization
    void Start () {

	}

    // Update is called once per frame
    void Update() {
     //   this.transform.Translate(Vector3.up*Time.deltaTime);
        if (!StopTime && transform.childCount < _maxInsects)
        {
            timer += Time.deltaTime;
            if (timer >= RefreshTime)
            {
                GameObject Tbug = GameObject.Instantiate(bug);
                BugsAutoMove insectMotion = Tbug.GetComponent<BugsAutoMove>();
                insectMotion._endingPt = _endingPt;
                insectMotion._startingPt = _startingPt;
                insectMotion._midwayPt = _midwayPt;
                insectMotion.Xrange = MaxRandomRange_x;
                // Tbug.transform.eulerAngles = this.transform.eulerAngles;
                // Tbug.transform.position = this.transform.position;
                Tbug.transform.parent = this.transform;
                // Tbug.GetComponent<BugsAutoMove>().Speed =  BugsSpeed;
                timer = 0;
            }

         }
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("BUGSAVOID")) {
            _endingPt = _startingPt;
        }
    }
}
