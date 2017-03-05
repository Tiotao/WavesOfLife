using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ContactEggEffect : MonoBehaviour {
	public GameObject _Name;
    public GameObject _Glow;
    public GameObject _WhiteOverylay;
	public GameObject _BackgroundMusic;
    public float _effectDuration;
    float _currentExposure;
    float _targetExposure;
	AudioSource _audio;
	bool _isAudioPlayed = false;
	bool IfShowName=false;
    
    bool _isBrightenUp = false;
    float t = 0f;
    

	// Use this for initialization
	void Start () {
		_audio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	    if (_isBrightenUp && t <= _effectDuration)
        {
            t = t + Time.deltaTime;
            float intensity = Mathf.Lerp(0f, 1f, t);
            // _camera.GetComponent<Camera>
            _Glow.transform.localScale = new Vector3(intensity * 10f, intensity * 10f, 1f);
            _WhiteOverylay.GetComponent<Image>().color = new Color(1, 1, 1, intensity);
			if (!IfShowName) {
				Invoke ("NameShow",2.0f);
				IfShowName = true;
			}
		}

		if (t >= _effectDuration && !_isAudioPlayed) {
			_isAudioPlayed = true;
			_audio.Play ();
		}
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isBrightenUp = true;
        }
    }
	void NameShow()
	{
		_Name.SetActive(true);
		Invoke ("ChangeScene",7.0f);
	}
	void ChangeScene()
	{
		DontDestroyOnLoad (_BackgroundMusic);
		SceneManager.LoadScene ("End");
	}
}
