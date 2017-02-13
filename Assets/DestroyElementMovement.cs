using UnityEngine;
using System.Collections;

public class DestroyElementMovement : MonoBehaviour {

    public float alpha;
    public Color colorPicker = new Color(0.5f, 0.5f, 0.5f);
    float flyDelay;
    public GameObject _target;
    public GameObject _camera;
    public bool _isName = false;
    public bool _isExpanding = false;
    public float _positionRange = 20f;
    public float _delayRange = 2f;
    public float _expandRange = 1f;

    

    void Awake()
    {

        if (gameObject.GetComponent<MeshRenderer>())
        {
            gameObject.GetComponent<MeshRenderer>().material.SetColor("_Color", colorPicker);
        } else if (gameObject.GetComponent<SpriteRenderer>())
        {
            gameObject.GetComponent<SpriteRenderer>().color = colorPicker;
        }
       

        if (_isName) {
            // name
            RandomNames _RandomNames = GameObject.Find("Random Names").GetComponent<RandomNames>();
            string _name = _RandomNames.GetName();
            TextMesh text = GetComponent<TextMesh>();
            text.text = _name;
            text.fontSize = Random.Range(16, 50);
        }

        
        

        _target = GameObject.Find("Player");
        _camera = GameObject.Find("Main Camera");
    }

    // Use this for initialization
    void Start()
    {
        // element appear orientationa
        transform.localPosition = new Vector3(Random.Range(-_positionRange, _positionRange), Random.Range(-_positionRange, _positionRange), Random.Range(-_positionRange, _positionRange)) - _positionRange * 2 * _target.transform.forward;
        transform.localEulerAngles = new Vector3(Camera.main.transform.eulerAngles.x, Camera.main.transform.eulerAngles.y, Camera.main.transform.eulerAngles.z) + new Vector3(Random.Range(-_positionRange, _positionRange), Random.Range(-_positionRange, _positionRange), Random.Range(-_positionRange, _positionRange));
        transform.Rotate(Vector3.back * 180);
        transform.localScale = new Vector3(0, 0, 0);
        
        // element appear time delay
        flyDelay = Random.Range(0, _delayRange);
        // float expandScale = Random.Range(1f, _expandRange);

        // fade in and fade out
        iTween.FadeTo(gameObject, iTween.Hash("alpha", 1f, "time", 1f, "delay", flyDelay, "easeType", "linear"));
        iTween.FadeTo(gameObject, iTween.Hash("alpha", 0f, "time", 5f, "delay", flyDelay + 1f, "easeType", "linear"));

        if (_isExpanding)
        {
            ShakeScale(iTween.Hash("prevScale", 0f, "isIncreasing", true));
        }



    }

    void ShakeScale(Hashtable completeParams)
    {
        float shakeTime = Random.Range(0.5f, 2f);
        float scale;
        float prevScale = (float) completeParams["prevScale"];
        bool isIncreasing = (bool)completeParams["isIncreasing"];
        if (isIncreasing)
        {
            scale = prevScale + Random.Range(0.5f, 1f);
            isIncreasing = false;
        } else
        {
            scale = prevScale - Random.Range(0f, 0.2f);
            isIncreasing = true;
        }

        if (scale < 0)
        {
            scale = 0;
        }
        
        iTween.ScaleTo(gameObject, iTween.Hash("easeType", iTween.EaseType.easeInOutSine, "scale", new Vector3(scale+ Random.Range(-0.1f, 0.1f), scale+ Random.Range(-0.1f, 0.1f), scale + Random.Range(-0.1f, 0.1f)), "time", shakeTime, "oncomplete", "ShakeScale", "oncompletetarget", gameObject, "oncompleteparams", iTween.Hash("prevScale", scale, "isIncreasing", isIncreasing)));
    }

    // Update is called once per frame
    void Update()
    {
        // 
    }

}
