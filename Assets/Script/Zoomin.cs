using UnityEngine;
using System.Collections;

public class Zoomin : MonoBehaviour {
    public Camera _C;
    private bool ZoomOut, ZoomIn;
    private float _V = 0;
    private float amount;
    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {

        if (ZoomOut)
        {
            _C.orthographicSize = Mathf.SmoothDamp(_C.orthographicSize, amount, ref _V, 0.5f);
            if (_C.orthographicSize == amount)
            {
                ZoomOut = false;
            }
        }
        if (ZoomIn)
        {
            _C.orthographicSize = Mathf.SmoothDamp(_C.orthographicSize, amount, ref _V, 0.5f);
            if (_C.orthographicSize == amount)
            {
                ZoomIn = false;
            }
        }
    }
    public void Zoom_in(float a)
    {
        amount = a;
        ZoomIn = true;
    }
    public void Zoom_out(float a)
    {
        amount = a;
        ZoomOut = true;
    }
}
