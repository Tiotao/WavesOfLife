using UnityEngine;
using System.Collections;

public class GlowPointTrigger : MonoBehaviour {

    public float _glowPathTime = 10f;
    public GlowPointController _controller;
    public bool _firstTrigger = false;

    public bool _effectTrigger = false;

    public GameObject _bugAvoidCollider;

    void TurnOnCollider() {
        if (_bugAvoidCollider) {
            _bugAvoidCollider.GetComponent<CapsuleCollider>().enabled = true;
        }
    }

	void OnTriggerEnter(Collider other)
    {
        
        
        if (other.CompareTag("Player")) {
            if (_firstTrigger) {
                TurnOnCollider();
                _controller._pathStarted = true;
                _controller.NextStage();
                

            } else if (_effectTrigger) {
                TurnOnCollider();
                _controller.NextStage();

            } else {
                if (_controller._pathStarted) {
                    _controller.NextStage();
                }
            }
            GetComponent<BoxCollider>().enabled = false;
        }
            
    }
}
