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
	// Use this for initialization
	void Start () {
        float rand = Random.Range(0, 4);
        if (rand <= 2)
            this.GetComponentInChildren<SpriteRenderer>().sprite = P1;
        else 
        {
            this.GetComponentInChildren<SpriteRenderer>().sprite = P2;
            _sprite.transform.eulerAngles = new Vector3(0,0,-90f);
        }
        rand = Random.Range(1,2);
        this.transform.localScale = new Vector3(rand,rand,rand);
        RanDirection = Random.Range(-30, 30);
        InitRotation = this.transform.eulerAngles;
    }
	
	// Update is called once per frame
	void Update () {
      
        if (!TimeStop)
            this.transform.Translate(Vector3.up * Time.deltaTime*60f*Speed);

        timer += Time.deltaTime;
        if(timer>=0.5f)
        {
            RanDirection = Random.Range(-30, 30);

            InitRotation = this.transform.eulerAngles;
            timer = 0;
        }

        if (Mathf.Abs(this.transform.eulerAngles.z - InitRotation.z) < Mathf.Abs(RanDirection))
        {
            if(RanDirection>=0)
                this.transform.Rotate(new Vector3(0, 0, 1));
            else
            {
                this.transform.Rotate(new Vector3(0, 0, -1));
                Debug.Log("-1");
            }
        }

    }
}
