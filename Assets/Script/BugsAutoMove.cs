using UnityEngine;
using System.Collections;

public class BugsAutoMove : MonoBehaviour {
    public bool TimeStop;
    public float Speed;
    public Sprite P1, P2, P3;
    public GameObject _sprite;
	// Use this for initialization
	void Start () {
        float rand = Random.Range(0, 4);
        if (rand <= 1)
            this.GetComponentInChildren<SpriteRenderer>().sprite = P1;
        else if (rand <= 2)
        {
            this.GetComponentInChildren<SpriteRenderer>().sprite = P2;
            _sprite.transform.eulerAngles = new Vector3(0,0,-90f);
        }
        else
            this.GetComponentInChildren<SpriteRenderer>().sprite = P3;
    }
	
	// Update is called once per frame
	void Update () {
        if (!TimeStop)
            this.transform.Translate(Vector3.up * Time.deltaTime*60f*Speed);

    }
}
