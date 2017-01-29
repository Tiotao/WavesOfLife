using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GetText : MonoBehaviour {
	public GameObject Data;
	public float _effectDuration = 2f;
	public float _showDuration = 2f;
	bool _isBrightenUp = false;
	bool _isFading = false;
	float t;


	// Use this for initialization
	void Start () {
		Data = GameObject.FindGameObjectWithTag ("DATA");
		if (Data) {
			this.GetComponent<Text> ().text = "Welcome to this world, " + Data.GetComponent<data> ().Name;
		} else {
			this.GetComponent<Text> ().text = "Welcome to this world, Stranger.";
		}

		_isBrightenUp = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (_isBrightenUp && t <= _effectDuration)
		{
			t = t + Time.deltaTime;
			float intensity = Mathf.Lerp(0f, 1f, t);
			// _camera.GetComponent<Camera>
			gameObject.GetComponent<Text>().color = new Color(0, 0, 0, intensity);
		}

		if (t > _effectDuration && _isBrightenUp)
		{
			t = t + Time.deltaTime;

		}

		if (t > _effectDuration + 3f && _isBrightenUp)
		{
			_isFading = true;
			_isBrightenUp = false;
			t = 0f;
		}

		if (_isFading && t <= _effectDuration)
		{
			t = t + Time.deltaTime;
			float intensity = Mathf.Lerp(1f, 0f, t);
			gameObject.GetComponent<Text>().color = new Color(0, 0, 0, intensity);
		}
	}
}
