using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AsyncSceneLoader : MonoBehaviour {

    AsyncOperation a;
    public GameObject _LoadingImage;

    public GameObject _SceneSelectionCanvas;

    float t = 0f;
	public float _effectDuration = 2f;
	public GameObject _BlackOverlay;
	bool _isFading = false;

    bool _isAllowingFade = false;

    AudioSource _audio;

    // Use this for initialization
    void Start () {
        
        _audio = GameObject.Find ("BackgroundSound").GetComponent<AudioSource> ();
    }
	
	// Update is called once per frame
	void Update () {
        if(a != null && a.progress >= 0.9f) {
            _isAllowingFade = true;
        }

        if (_isAllowingFade && !_isFading) {
            StartCoroutine(FadeToBlack());
        }

        if (_isFading && t <= _effectDuration)
		{
			t = t + Time.deltaTime;
			float intensity = Mathf.Lerp(0f, 1f, t);
			// _camera.GetComponent<Camera>
			_BlackOverlay.GetComponent<Image>().color = new Color(0, 0, 0, intensity);
			_audio.volume = 1 - intensity;
		}
    }

    IEnumerator FadeToBlack() {
        _isFading = true;
        _BlackOverlay.SetActive(true);
        yield return new WaitForSeconds (_effectDuration);
        a.allowSceneActivation = true;

    }

    public void ToSelectedScene(int sceneIndex) {
        _SceneSelectionCanvas.SetActive(false);
        a = SceneManager.LoadSceneAsync(sceneIndex);
        a.allowSceneActivation = false;
        _LoadingImage.SetActive(true);
        
    }
}
