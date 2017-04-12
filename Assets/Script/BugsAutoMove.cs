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
        
        Respawn();
        // rand = Random.Range(0.5f,1f);
        // this.transform.localScale = new Vector3(rand,rand,rand);
        // RanDirection = Random.Range(-10, 10);
        // InitRotation = this.transform.eulerAngles;
    }

    // void MoveDirectlyToEnd() {
    //     iTween.MoveTo(this.gameObject, iTween.Hash("position", randomizedEnding , "speed", 1f, "oncomplete", "DestroyInsect", "movetopath", true, "orienttopath",true, "easetype", iTween.EaseType.linear));
    // }

    void Respawn() {
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
    }
    
    void DestroyInsect () {
        Respawn();
    }

}
