using UnityEngine;
using System.Collections;

public class GlowPointTrigger : MonoBehaviour {

    public int _glowPathId;
    public GlowPointController _controller;

	void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            _controller.NextStage();
    }
}
