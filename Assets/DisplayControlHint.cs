using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayControlHint : MonoBehaviour {

	Image[] _images;

	int _shineConter;
	float _t = 0f;
	
	public float _effectDuration = 1f;
	public int _shineTimes = 3;

	

	// Use this for initialization
	void Start () {
		_images = gameObject.GetComponentsInChildren<Image>();
		_shineConter = _shineTimes;
	}
	
	// Update is called once per frame
	void Update () {
		if (_shineConter > 0) {
			if (_t <= _effectDuration) {
				foreach (Image img in _images) {
					img.color = new Color(img.color.r, img.color.g, img.color.b, _t / _effectDuration);
				}
			} else if (_t > _effectDuration && _t <= 2 * _effectDuration) {

			} else if (_t > 2 * _effectDuration && _t <= 3* _effectDuration){
				foreach (Image img in _images) {
					img.color = new Color(img.color.r, img.color.g, img.color.b, 1f - (_t - 2*_effectDuration) / _effectDuration);
				}
			} else {
				_t = 0;
				_shineConter--;
			}
			_t = _t + Time.deltaTime;
		} else {
			gameObject.SetActive(false);
		}
		
	}

}
