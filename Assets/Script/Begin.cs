using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class Begin : MonoBehaviour {

	public GameObject _TouchController;
	public GameObject _Camera;
	public bool _toSceneSelection = false;

	AudioSource _audio;
	
	Vector3 _targetCamPosition = new Vector3(19.7f, -18f, -2.58f);
	Vector3 _targetCamRotation = new Vector3(0f, 0f, -90f);

    // Use this for initialization
    void Start () {
		_audio = GetComponent<AudioSource>();
        
    }
	
	// Update is called once per frame
	void Update () {
		if (_toSceneSelection) {
			ToSceneSelection();
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Player")) {
			_toSceneSelection = true;
			other.gameObject.SetActive(false);
			if (!_audio.isPlaying) {
				_audio.Play();
			}
		}
	}

	void ToSceneSelection() {
		_toSceneSelection = false;
		
		// disable player control
		_Camera.GetComponent<CameraFollow>().enabled = false;
		_TouchController.SetActive(false);

		// move Camera
		iTween.MoveTo(_Camera, iTween.Hash("position", _targetCamPosition, "time", 3f, "easeType", iTween.EaseType.easeOutBack));
		iTween.RotateTo(_Camera, iTween.Hash("rotation", _targetCamRotation, "time", 3f, "easeType", iTween.EaseType.easeOutBack));

	}

}
