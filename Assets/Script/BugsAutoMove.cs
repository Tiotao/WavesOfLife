using UnityEngine;
using System.Collections;

public class BugsAutoMove : MonoBehaviour {
    public bool TimeStop;
    public float Speed;
    public Sprite P1, P2;
    public GameObject _sprite;
    private float timer=0f;
    private bool BeginRotate=false;
    private float RanDirection;
    private Vector3 InitRotation;
    

    
    public Transform _endingPt;
    public Transform _startingPt;

    public Transform _midwayPt;

    //range of random start position
    public float Xrange;

    Vector3 randomizedEnding;
    Vector3 randomizedMidway;

    
	// Use this for initialization
	void Start () {
        
        transform.position = new Vector3(_startingPt.position.x + Random.Range(-Xrange, Xrange), _startingPt.position.y + Random.Range(0f, 1f), _startingPt.position.z);
        randomizedEnding = new Vector3(_endingPt.position.x + Random.Range(-2f, 2f), _endingPt.position.y + Random.Range(0f, 1f), _endingPt.position.z);
        randomizedMidway = new Vector3(_midwayPt.position.x + Random.Range(-1f, 1f), _midwayPt.position.y + Random.Range(0f, 0f), _midwayPt.position.z);
        

        iTween.MoveTo(this.gameObject, iTween.Hash("path", new Vector3[]{randomizedMidway, randomizedEnding} , "time", Random.Range(4f, 6f), "oncomplete", "DestroyInsect", "movetopath", true, "orienttopath",true, "easetype", iTween.EaseType.linear));

        float rand = Random.Range(0, 4);
        float randomSizeFactor = Random.Range(1f, 1.5f);
        this.GetComponentInChildren<SpriteRenderer>().transform.localScale = new Vector3(randomSizeFactor, randomSizeFactor, randomSizeFactor);
        if (rand <= 2)
            this.GetComponentInChildren<SpriteRenderer>().sprite = P1;
        else 
        {
            this.GetComponentInChildren<SpriteRenderer>().sprite = P2;
            // _sprite.transform.eulerAngles = new Vector3(0,0,-90f);
        }
        // rand = Random.Range(0.5f,1f);
        // this.transform.localScale = new Vector3(rand,rand,rand);
        // RanDirection = Random.Range(-10, 10);
        // InitRotation = this.transform.eulerAngles;
    }

    // void MoveDirectlyToEnd() {
    //     iTween.MoveTo(this.gameObject, iTween.Hash("position", randomizedEnding , "speed", 1f, "oncomplete", "DestroyInsect", "movetopath", true, "orienttopath",true, "easetype", iTween.EaseType.linear));
    // }

    void DestroyInsect () {
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other) {
        // if (other.CompareTag("BUGSAVOID")) {
        //     iTween.Stop(gameObject);
            
            
        //     Vector3 avoiderPos = other.gameObject.transform.position;
        //     Debug.Log(other.gameObject.transform.forward);
        //     Debug.Log(transform.forward);
        //     float angle = Vector3.Angle(transform.position - avoiderPos, other.gameObject.transform.forward);
        //     float sideAngle = Vector3.Angle(transform.position - avoiderPos, other.gameObject.transform.right);
            
        //     Vector3 topTarget;
        //     if (angle <= 90f) {
        //         topTarget = new Vector3(avoiderPos.x + 6f, avoiderPos.y, randomizedEnding.z);
        //     } else {
        //         topTarget = new Vector3(avoiderPos.x - 6f, avoiderPos.y, randomizedEnding.z);
        //     }

        //     if (sideAngle <= 90f) {
        //         topTarget = new Vector3(topTarget.x, topTarget.y + 3f * (sideAngle / 90), randomizedEnding.z);
        //     } else {
        //         topTarget = new Vector3(topTarget.x, topTarget.y + 3f * (sideAngle % 90 / 90), randomizedEnding.z);
        //     }
            
            

        //     iTween.MoveTo(this.gameObject, iTween.Hash("path", new Vector3[]{topTarget, randomizedEnding} , "speed", 8f, "oncomplete", "DestroyInsect", "movetopath", true, "orienttopath",true, "easetype", iTween.EaseType.linear));
        // }
    }
	
	// Update is called once per frame
	void Update () {

        
      
        // if (!TimeStop)
        //     this.transform.Translate(Vector3.up * Time.deltaTime*60f*Speed);

        // timer += Time.deltaTime;
        // if(timer>=0.5f)
        // {
        //     RanDirection = Random.Range(-10, 10);

        //     InitRotation = this.transform.eulerAngles;
        //     timer = 0;
        // }

        // if (Mathf.Abs(this.transform.eulerAngles.z - InitRotation.z) < Mathf.Abs(RanDirection))
        // {
        //     if(RanDirection>=0)
        //         this.transform.Rotate(new Vector3(0, 0, 1));
        //     else
        //     {
        //         this.transform.Rotate(new Vector3(0, 0, -1));
        //         Debug.Log("-1");
        //     }
        // }

    }
}
