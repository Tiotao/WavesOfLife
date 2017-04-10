using UnityEngine;
using System.Collections;

public class GlowPointTrigger : MonoBehaviour {

    public float _glowPathTime = 10f;
    public GlowPointController _controller;
    public bool _firstTrigger = false;


	void OnTriggerEnter(Collider other)
    {
        
        
        if (other.CompareTag("Player")) {
            if (_firstTrigger) {
                _controller._pathStarted = true;
                _controller.NextStage();
            } else {
                if (_controller._pathStarted) {
                    _controller.NextStage();
                }
            }
        }
            
    }
}
