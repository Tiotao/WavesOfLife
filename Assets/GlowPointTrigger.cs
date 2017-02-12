using UnityEngine;
using System.Collections;

public class GlowPointTrigger : MonoBehaviour {

    public float _glowPathTime = 10f;
    public GlowPointController _controller;

	void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            _controller.NextStage();
    }
}
