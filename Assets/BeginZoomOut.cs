using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginZoomOut : MonoBehaviour {
    public Camera _C;
    private bool ZoomOut, ZoomIn;
    private float _V = 0;
    private float amount;
    // Use this for initialization
    void Start()
    {
        amount = 7f;
        ZoomOut = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (ZoomOut)
        {
            _C.orthographicSize = Mathf.SmoothDamp(_C.orthographicSize, amount, ref _V, 25f);
            if (_C.orthographicSize == amount)
            {
                ZoomOut = false;
            }
        }
        
    }
   
}
