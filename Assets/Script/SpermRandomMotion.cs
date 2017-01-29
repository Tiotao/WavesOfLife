using UnityEngine;
using System.Collections;

public class SpermRandomMotion : MonoBehaviour {

    Vector3 randomTarget;
    public float _moveRange;
    public float _moveRangeMin = 0.5f;
    public float _moveRangeMax = 1f;
    public float _moveTimeLowRange = 0.5f;
    public float _moveTimeHighRange = 1f;

    // Use this for initialization
    void Start () {
        // transform.localPosition = new Vector3(Random.Range(-_moveRange * 2, _moveRange * 2), Random.Range(-_moveRange * 2, _moveRange * 2), Random.Range(-_moveRange * 2, 0f));
        moveCompleted();

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            _moveRange = _moveRangeMin;
        } else
        {
            _moveRange = _moveRangeMax;
        }

	}

    void moveCompleted()
    {
        int position = Random.Range(0, 3);
        float moveTime = Random.Range(_moveTimeLowRange, _moveTimeHighRange);

        switch (position)
        {
            case 0:
                randomTarget = new Vector3(Random.Range(-_moveRange * 2, _moveRange * 2), Random.Range(-_moveRange * 2, _moveRange * 2), Random.Range(-_moveRange * 2, 0f));
                break;
            case 1:
                randomTarget = new Vector3(Random.Range(-_moveRange * 2, -_moveRange), Random.Range(-_moveRange * 2, _moveRange * 2), Random.Range(-_moveRange * 2, 0f));
                break;
            case 2:
                randomTarget = new Vector3(Random.Range(_moveRange, _moveRange * 2), Random.Range(-_moveRange * 2, _moveRange * 2), Random.Range(-_moveRange * 2, 0f));
                break;
            default:
                break;
        }
        // randomTarget = new Vector3 (Random.Range (-RANGE*2, RANGE*2), Random.Range (-RANGE, -0.5f), Random.Range (-RANGE*2, 0.2f));
        iTween.MoveTo(gameObject, iTween.Hash("position", randomTarget, "isLocal", true, "time", moveTime, "orientToPath", false, "easetype", "easeInOutSine", "oncomplete", "moveCompleted", "oncompletetarget", gameObject));
    }

}
