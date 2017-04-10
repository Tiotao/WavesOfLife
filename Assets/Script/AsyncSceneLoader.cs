using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AsyncSceneLoader : MonoBehaviour {

    
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
        _audio = GameObject.Find ("BackgroundMusic").GetComponent<AudioSource> ();
        
    }
	
	// Update is called once per frame
	void Update () {
        // if(a != null && a.progress >= 0.9f) {
        //     _isAllowingFade = true;
        // }

        // if (_isAllowingFade && !_isFading) {
        //     StartCoroutine(FadeToBlack());
        // }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (SceneManager.GetActiveScene().buildIndex == 4) {
                Application.Quit();
            } else {
                ToSelectedScene(4); 
            }
            
        }

        if (_isFading && t <= _effectDuration)
		{
			t = t + Time.deltaTime;
			float intensity = Mathf.Lerp(0f, 1f, t / _effectDuration);
			// _camera.GetComponent<Camera>
			_BlackOverlay.GetComponent<Image>().color = new Color(0, 0, 0, intensity);
			_audio.volume = 1 - intensity;
		}
    }

    // IEnumerator FadeToBlack() {
    //     _isFading = true;
    //     _BlackOverlay.SetActive(true);
    //     yield return new WaitForSeconds (_effectDuration);
    //     a.allowSceneActivation = true;
    // }

    public void ToSelectedScene(int sceneIndex) {
        StartCoroutine(Load(sceneIndex));
    }


    IEnumerator Load(int sceneIndex) {
        if (_SceneSelectionCanvas != null) {
            _SceneSelectionCanvas.SetActive(false);
        }
        
        AsyncOperation a = SceneManager.LoadSceneAsync(sceneIndex);
        a.allowSceneActivation = false;

        _LoadingImage.SetActive(true);
        while(a.progress < 0.9f){
            yield return null;
        }
        _isFading = true;
        _BlackOverlay.GetComponent<FadeInWhenBeginning>().FadeOut(2f, 0f);
        yield return new WaitForSeconds(2f);
        a.allowSceneActivation = true;
        
        
    }

}
