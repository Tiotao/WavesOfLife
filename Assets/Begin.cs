using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
public class Begin : MonoBehaviour {

	float t = 0f;
	public float _effectDuration = 2f;
	public GameObject _WhiteOverlay;
	bool _isFading = false;
	AudioSource _audio;


	// Use this for initialization
	void Start () {
		_audio = GameObject.Find ("BackgroundSound").GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (_isFading && t <= _effectDuration)
		{
			t = t + Time.deltaTime;
			float intensity = Mathf.Lerp(0f, 1f, t);
			// _camera.GetComponent<Camera>
			_WhiteOverlay.GetComponent<Image>().color = new Color(0, 0, 0, intensity);
			_audio.volume = 1 - intensity;
		}
	}

	IEnumerator LoadNextScene() {
		yield return new WaitForSeconds (3f);
		SceneManager.LoadScene("Main");
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.CompareTag ("Player")) {
			_WhiteOverlay.SetActive (true);
			_isFading = true;
			StartCoroutine(LoadNextScene ());
            //Debug.Log ("BeginGame");
		}
	}
}
