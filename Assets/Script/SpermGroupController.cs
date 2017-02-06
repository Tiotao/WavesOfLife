using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SpermGroupController : MonoBehaviour {

    public int _initSpermAmount = 1;
    public GameObject _SpermObject;
	public GameObject _BlackOverlay;
	public AudioSource _audio;
    
	bool _isDying = false;
	bool _isChecking = false;
	bool _isFading = false;
	float _fadingDuration = 1f;
	float t = 0f;

	// Use this for initialization
	void Start () {
        SpawnSperms(_initSpermAmount);
        
    }
	
	// Update is called once per frame
	void Update () {
		if (transform.childCount == 0 && !_isChecking) {
			_isDying = true;
		}

		if (_isDying && !_isChecking) {
			StartCoroutine(GameEnd());
			_isChecking = true;
		}

		if (_isFading && t <= _fadingDuration)
		{
			t = t + Time.deltaTime;
			float intensity = Mathf.Lerp(0f, 1f, t);
			// _camera.GetComponent<Camera>
			_BlackOverlay.GetComponent<Image>().color = new Color(0, 0, 0, intensity);
			_audio.volume = 1f - intensity;
		}
	}

	IEnumerator GameEnd() {
		yield return new WaitForSeconds (5f);
		if (transform.childCount == 0) {
			_isFading = true;
		}
		yield return new WaitForSeconds (1f);

		if (transform.childCount == 0) {
			
			DontDestroyOnLoad (GameObject.Find("Data"));
			SceneManager.LoadScene (SceneManager.GetActiveScene().name);
		} else {
			_isChecking = false;
			_isDying = false;
		}




	}

    void SpawnSperms(int spermAmount)
    {
        for (int i = 0; i < spermAmount; i++)
        {
            GameObject sperm = Instantiate(_SpermObject) as GameObject;
            sperm.transform.parent = transform;
			sperm.transform.localPosition = new Vector3 (0, 0, 0);
        }

    }

    void SpawnLastSperm()
    {
        GameObject sperm = Instantiate(_SpermObject) as GameObject;
        Debug.Log(sperm);
        sperm.transform.parent = transform;
        sperm.transform.localPosition = new Vector3(0, 0, 0);
        sperm.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        sperm.transform.Find("Glow").localScale = new Vector3(1.5f, 1.5f, 1.5f);
        sperm.transform.Find("Glow").GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1f);
        sperm.transform.Find("SpermTail").GetComponent<TrailRenderer>().startWidth = 0.03f;
        sperm.transform.Find("SpermTail").GetComponent<TrailRenderer>().time = 2f;
    }

    public void LeftOne()
    {
        StartCoroutine(GenerateFinalSperm());  
    }

    IEnumerator GenerateFinalSperm()
    {
        yield return new WaitForSeconds(3f);
        Debug.Log("yay");
        SpawnLastSperm();
    }

}
