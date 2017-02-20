using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TouchEffectController : MonoBehaviour {

    public GameObject _TouchTrace;
    public float _fadeRate;
    private Image _TraceImage;
    private float _targetAlpha;

    // Use this for initialization
    void Start () {
        iTween.FadeTo(_TouchTrace, 0f, 0f);
        _TraceImage = _TouchTrace.GetComponent<Image>();
        _targetAlpha = _TraceImage.material.color.a;
        _targetAlpha = 0.0f;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.touchCount == 1)
        { //Does finger count on screen equal 1?
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            { //When touch on the touch screen begins.
                _TouchTrace.transform.position = Input.GetTouch(0).position;
                _targetAlpha = 1.0f;
            }
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            { //When touch on the touch screen ends.
                _targetAlpha = 0.0f;
            }
        }

        Color curColor = _TraceImage.color;
        float alphaDiff = Mathf.Abs(curColor.a - _targetAlpha);

        if (alphaDiff > 0.0001f)
        {
            curColor.a = Mathf.Lerp(curColor.a, _targetAlpha, _fadeRate * Time.deltaTime);
            _TraceImage.color = curColor;
        }

        
        
    
    }
    
    void HandleTouch(Touch t)
    {

    }
}


     