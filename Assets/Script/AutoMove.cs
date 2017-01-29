using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class AutoMove : MonoBehaviour {

    public bool _usingKey = false;
	public float Speed;
	public float TSpeed;
    public bool LDown = false;
    public bool RDown = false; 
	private float OriTSpeed;
	public Transform _camera;
	public Camera _C;
	public bool ZoomOut;
	public bool ZoomIn;
	private float _V = 0;
	public bool END=false;
	AudioSource _audio;

    public GameObject _controllerCanvas;
    public PointerListener _leftTouchBtn;
    public PointerListener _rightTouchBtn;

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
        if(Speed<=0.05f) {
            Speed += (0.000025f * Time.deltaTime * 60f);
        }

        if (!END)
        {

            if (Input.GetAxis("Horizontal") < 0 || _leftTouchBtn.Pressed)
            {
                LDown = true;
                /*
                this.transform.Rotate(new Vector3(1, 0, 0) * TSpeed);
                _camera.transform.Rotate(new Vector3(0, 0, 1) * TSpeed);
                TSpeed = OriTSpeed * 1.5f * Mathf.Abs(Input.GetAxis("Horizontal"));
                */
            } else if (Input.GetAxis("Horizontal") > 0 || _rightTouchBtn.Pressed)
            {
                RDown = true;
                /*
                this.transform.Rotate(new Vector3(-1, 0, 0) * TSpeed);
                _camera.transform.Rotate(new Vector3(0, 0, -1) * TSpeed);
                TSpeed = OriTSpeed * 1.5f * Mathf.Abs(Input.GetAxis("Horizontal"));
                */
            } else
            {
                RDown = false;
                LDown = false;
                TSpeed = OriTSpeed;
            }

        }

        this.transform.Translate(new Vector3(0, 0, 1) * Speed * Time.deltaTime * 60f);

        
		if (LDown&&!END) {
			this.transform.Rotate(new Vector3 (1, 0, 0) * TSpeed);
			_camera.transform.Rotate(new Vector3 (0, 0, 1) * TSpeed);
			//float x=_camera.transform.eulerAngles.x;
		//	float y=_camera.transform.eulerAngles.y;
			//float z=_camera.transform.eulerAngles.z+1.0f;
		//	Quaternion target=Quaternion.Euler(x,y,z);
		//	StartCoroutine(WaitAndRotate(0.3f,new Vector3(0,0,1)));
			TSpeed = TSpeed * 1.015f;
		}
		if (RDown&&!END) {
			this.transform.Rotate(new Vector3 (-1, 0, 0) * TSpeed);
			_camera.transform.Rotate(new Vector3 (0, 0, -1) * TSpeed);
            //	float x=_camera.transform.eulerAngles.x;
            //	float y=_camera.transform.eulerAngles.y;
            //	float z=_camera.transform.eulerAngles.z-1.0f;
            //	Quaternion target=Quaternion.Euler(x,y,z);
            //_camera.transform.rotation=Quaternion.Slerp(_camera.transform.rotation,target,TSpeed*0.1f);
            //StartCoroutine(WaitAndRotate(0.3f,new Vector3(0,0,-1)));
            TSpeed = TSpeed * 1.015f;
        }
        
    }
	IEnumerator BackToOrigin(float waitTime)
	{
		yield return new WaitForSeconds (waitTime);
		Speed =0.05f;
		ZoomIn = true;
		ZoomOut = false;
        _C.GetComponent<UnityStandardAssets.ImageEffects.MotionBlur>().blurAmount = 0.08f;
        //_camera.transform.rotation=Quaternion.Slerp(_camera.transform.rotation,target,TSpeed);
    }
	void OnTriggerEnter(Collider col)
	{
		if(col.CompareTag("SPEED"))
		{
			_audio.Play ();
			Speed =0.15f;
			ZoomOut = true;
            //  UnityStandardAssets.ImageEffects.
            _C.GetComponent<UnityStandardAssets.ImageEffects.MotionBlur>().blurAmount = 0.9f;
			StartCoroutine(BackToOrigin(2.2f));


			}
        if (col.CompareTag("SPEED1")) {
			_audio.Play ();
            Speed = 0.15f;
            ZoomOut = true;
            //  UnityStandardAssets.ImageEffects.
            _C.GetComponent<UnityStandardAssets.ImageEffects.MotionBlur>().blurAmount = 0.9f;
            StartCoroutine(BackToOrigin(1.5f));


        }
    }
}

