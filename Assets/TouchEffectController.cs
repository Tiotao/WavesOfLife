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
        
        if (Input.GetMouseButton(0))
        {
            _TouchTrace.transform.position = Input.mousePosition;
            _targetAlpha = 1.0f;

        }
        
        if (Input.GetMouseButtonUp(0))
        {
            _targetAlpha = 0.0f;
        }

        Color curColor = _TraceImage.color;
        float alphaDiff = Mathf.Abs(curColor.a - _targetAlpha);

        if (alphaDiff > 0.0001f)
        {
            curColor.a = Mathf.Lerp(curColor.a, _targetAlpha, _fadeRate * Time.deltaTime);
            _TraceImage.color = curColor;
        }

        /**
        if (Input.touchCount == 1)
        { //Does finger count on screen equal 1?
            if (Input.GetTouch(0).phase == TouchPhase.Began && _TouchTrace == null)
            { //When touch on the touch screen begins.
                Vector2 fTC = Input.GetTouch(0).position;
                _TouchTrace.transform.position = fTC;
                iTween.FadeTo(_TouchTrace, 1f, 0.2f);
            }
            if (Input.GetTouch(0).phase == TouchPhase.Ended && _TouchTrace != null)
            { //When touch on the touch screen ends.
                iTween.FadeTo(_TouchTrace, 0f, 0.2f);
            }
        }
    **/
    }
    
    void HandleTouch(Touch t)
    {

    }
}


     