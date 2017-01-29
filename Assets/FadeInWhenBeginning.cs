using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeInWhenBeginning : MonoBehaviour {

	float t = 0f;
	bool _isFading = false;
	public float _effectDuration = 1f;

	// Use this for initialization
	void Start () {
		StartCoroutine(StartFading ());
	}
	
	// Update is called once per frame
	void Update () {
		if (_isFading && t <= _effectDuration)
		{
			t = t + Time.deltaTime;
			float intensity = Mathf.Lerp(1f, 0f, t);
			// _camera.GetComponent<Camera>
			gameObject.GetComponent<Image>().color = new Color(0, 0, 0, intensity);
		}
	}

	IEnumerator StartFading() {
		yield return new WaitForSeconds (2f);
		_isFading = true;
	}
}
