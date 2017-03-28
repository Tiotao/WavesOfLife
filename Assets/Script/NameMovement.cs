using UnityEngine;
using System.Collections;

public class NameMovement : MonoBehaviour {

    public float alpha;
    public Color colourPicker = new Color(0.5f, 0.5f, 0.5f);
    public RandomNames _RandomNames;
    public string _name;
    float flyDelay;
    public GameObject _target;
    public GameObject _camera;
    private TextMesh text;

    void Awake()
    {
        this.gameObject.GetComponent<MeshRenderer>().material.SetColor("_Color", colourPicker);
        _RandomNames = GameObject.Find("Random Names").GetComponent<RandomNames>();
        _name = _RandomNames.GetName();
        text = GetComponent<TextMesh>();
        text.text = _name;
        text.fontSize = Random.Range(15, 50);
        _target = GameObject.Find("SpermGroup");
        _camera = GameObject.Find("Main Camera");
    }

    // Use this for initialization
    void Start() {
        transform.localPosition = new Vector3(Random.Range(-20f, 20f), Random.Range(-20f, 20f), Random.Range(-20f, 20f)) - 50 * _target.transform.forward;
        transform.localEulerAngles = new Vector3(Camera.main.transform.eulerAngles.x, Camera.main.transform.eulerAngles.y, Camera.main.transform.eulerAngles.z) + new Vector3(Random.Range(-20f, 20f), Random.Range(-20f, 20f), Random.Range(-20f, 20f));
        transform.Rotate(Vector3.back * 180);
        flyDelay = Random.Range(0, 2f);
        iTween.FadeTo(gameObject, iTween.Hash("alpha", 1f, "time", 1f, "delay", flyDelay, "easeType", "linear"));
        iTween.FadeTo(gameObject, iTween.Hash("alpha", 0f, "time", 2f, "delay", flyDelay+1f, "easeType", "linear"));
        // FollowPlayer();


    }
	
	// Update is called once per frame
	void Update () {
        // 
    }
    
    void FollowPlayer()
    {
        
        iTween.MoveTo(gameObject, iTween.Hash("position", _target.transform.position + Random.Range(0f, 10f) * _target.transform.forward, "time", 10f, "orienttopath", false,  "oncomplete", "FollowPlayer", "oncompletetarget", gameObject, "easeType", "linear"));
    }
    
}
