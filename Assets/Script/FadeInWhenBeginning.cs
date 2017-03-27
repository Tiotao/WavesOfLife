using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeInWhenBeginning : MonoBehaviour {

	float t = 0f;
	bool _isFading = false;

	bool _isFadingIn = true;
	public float _effectDuration = 1f;
	public float _delay = 0f;

	

	// Use this for initialization
	void Awake () {
		FadeIn(_effectDuration, _delay);
		//StartCoroutine(StartFading (_effectDuration, 2f, true));
	}
	
	// Update is called once per frame
	void Update () {
		if (_isFading && t <= _effectDuration)
		{
			t = t + Time.deltaTime;
			float intensity;
			if (_isFadingIn) {
				intensity = Mathf.Lerp(1f, 0f, t);
			} else {
				intensity = Mathf.Lerp(0f, 1f, t);
			}
			// _camera.GetComponent<Camera>
			gameObject.GetComponent<Image>().color = new Color(0, 0, 0, intensity);
		} else {
			_isFading = false;
			t = 0;
			// gameObject.SetActive(false);
		}
	}

	IEnumerator StartFading(float duration, float delay, bool isFadingIn) {
		yield return new WaitForSeconds (delay);
		_isFadingIn = isFadingIn;
		_effectDuration = duration;
		_isFading = true;
	}

	public void FadeOut(float duration, float delay) {
		StartCoroutine(StartFading(duration, delay, false));
		// gameObject.SetActive(false);
	}

	public void FadeIn(float duration, float delay) {
		// gameObject.SetActive(true);
		StartCoroutine(StartFading(duration, delay, true));
	}

	 
}
