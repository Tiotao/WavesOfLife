using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class AutoMove : MonoBehaviour {
    //player state
    public bool HasSpeedUp;
    // game control
    public float Speed;
	public float TSpeed;	
    public float _lastHorizontalAxis = 0;
    private float OriTSpeed;
    public GameObject _controllerCanvas;
    public PointerListener _leftTouchBtn;
    public PointerListener _rightTouchBtn;
    public float MaxSpeed;

    // game state
    public bool END = false;

    // camera effect
    public Transform _camera;
	public Camera _C;
    public bool ZoomOut;
	public bool ZoomIn;
    private float _V = 0;
    public bool lvl1End=false;
    // sound effect
    private AudioSource _audio;
    
    // Use this for initialization
    void Start () {
		OriTSpeed = TSpeed;
		_audio = GetComponent<AudioSource> ();
        Cursor.visible = false;
        _leftTouchBtn = _controllerCanvas.GetComponentsInChildren<PointerListener>()[0];
        _rightTouchBtn = _controllerCanvas.GetComponentsInChildren<PointerListener>()[1];
    }

	// Update is called once per frame
	void Update () {

		if (ZoomOut) {
			_C.orthographicSize =  Mathf.SmoothDamp(_C.orthographicSize,9.0f,ref _V,0.5f);
			if (_C.orthographicSize == 9) {
				ZoomOut = false;
			}
		}
		if (ZoomIn) {
			_C.orthographicSize =  Mathf.SmoothDamp(_C.orthographicSize,7.0f,ref _V,0.5f);
			if (_C.orthographicSize == 7) {
				ZoomIn = false;
			}
		}
        if(Speed<= MaxSpeed) {
            Speed += (0.000025f * Time.deltaTime * 60f);
        }


        // Obtain keyboard or touch input

        if (!END&&!lvl1End)
        {

            // determine if keyboard value is increasing or decreasing
            float axisDifference = Input.GetAxis("Horizontal") - _lastHorizontalAxis;
            _lastHorizontalAxis = Input.GetAxis("Horizontal");

            // left turn
            if ((axisDifference < 0 && Input.GetAxis("Horizontal") < 0) || Input.GetAxis("Horizontal") == -1f || _leftTouchBtn.Pressed)
            {
                this.transform.Rotate(new Vector3(1, 0, 0) * TSpeed);
                _camera.transform.Rotate(new Vector3(0, 0, 1) * TSpeed);
                TSpeed = TSpeed * 1.015f;
            // right turn
            } else if (axisDifference > 0 && Input.GetAxis("Horizontal") > 0|| Input.GetAxis("Horizontal") == 1f || _rightTouchBtn.Pressed)
            {
                this.transform.Rotate(new Vector3(-1, 0, 0) * TSpeed);
                _camera.transform.Rotate(new Vector3(0, 0, -1) * TSpeed);
                TSpeed = TSpeed * 1.015f;
            // no turn
            } else
            {
                TSpeed = OriTSpeed;
            }


        }

        // player is moving forward all the time
        if(!lvl1End)
        {
            this.transform.Translate(new Vector3(0, 0, 1) * Speed * Time.deltaTime * 60f);
        }
            
        
    }
	IEnumerator BackToOrigin(float waitTime)
	{
		yield return new WaitForSeconds (waitTime);
        _C.GetComponent<UnityStandardAssets.ImageEffects.MotionBlur>().enabled = false;
		Speed =MaxSpeed;
		ZoomIn = true;
		ZoomOut = false;
        HasSpeedUp = false;
        _C.GetComponent<UnityStandardAssets.ImageEffects.MotionBlur>().blurAmount = 0.08f;
    }
	void OnTriggerEnter(Collider col)
	{
		if(col.CompareTag("SPEED"))
		{
			_audio.Play ();
			Speed =0.1f;
			ZoomOut = true;
            //  UnityStandardAssets.ImageEffects.
            _C.GetComponent<UnityStandardAssets.ImageEffects.MotionBlur>().enabled = true;
            _C.GetComponent<UnityStandardAssets.ImageEffects.MotionBlur>().blurAmount = 0.9f;
            HasSpeedUp = true;
            StartCoroutine(BackToOrigin(2.2f));


			}
        if (col.CompareTag("SPEED1")) {
			_audio.Play ();
            Speed = 0.5f;
            ZoomOut = true;
            HasSpeedUp = true;
            //  UnityStandardAssets.ImageEffects.
            _C.GetComponent<UnityStandardAssets.ImageEffects.MotionBlur>().enabled = true;
            _C.GetComponent<UnityStandardAssets.ImageEffects.MotionBlur>().blurAmount = 0.9f;
            StartCoroutine(BackToOrigin(0.3f));


        }
    }
}

