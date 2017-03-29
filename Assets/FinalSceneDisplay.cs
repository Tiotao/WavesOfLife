using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalSceneDisplay : MonoBehaviour {

	AsyncSceneLoader _async;
	TextMesh _text;

	bool _isFading;

	float t = 0f;
	public float _effectDuration = 2f;

	// Use this for initialization
	void Start () {
		_async = GameObject.FindObjectOfType<AsyncSceneLoader>();
		_text = GetComponent<TextMesh>();
		StartCoroutine(ToNextScene());
	}
	
	// Update is called once per frame
	void Update () {
		
		if (_isFading && t <= _effectDuration)
		{
			t = t + Time.deltaTime;
			float intensity = Mathf.Lerp(1f, 0f, t / _effectDuration);
			// _camera.GetComponent<Camera>
			_text.color = new Color(255, 255, 255, intensity);
			
		}
	}

	IEnumerator ToNextScene() {
		yield return new WaitForSeconds(3f);
		_isFading = true;
		yield return new WaitForSeconds(_effectDuration + 1f);
		_async.ToSelectedScene(0);
	}
	
}
