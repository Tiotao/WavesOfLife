using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SpermGroupController : MonoBehaviour {

    public int _initSpermAmount = 1;
    public GameObject _SpermObject;
	public GameObject _BlackOverlay;
	public AudioSource _audio;
    public int _levelNumber = 0;

    public bool _isDying = false;
	public bool _isChecking = false;
	public bool _isFading = false;
    
	float _fadingDuration = 1f;
	float t = 0f;

    public float _maxInstanceScale = 0.3f;
    public float _minInstanceScale = 0.3f;

    private int _spawnCount = 0;


	// Use this for initialization
	void Start () {
        // SpawnSperms(_initSpermAmount);
        
    }
	
	// Update is called once per frame
	void Update () {

        SpawnSperms(_initSpermAmount);

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
			_BlackOverlay.GetComponent<Image>().color = new Color(0, 0, 0, intensity);
			_audio.volume = 1f - intensity;
		}
	}

	IEnumerator GameEnd() {
		yield return new WaitForSeconds (3f);
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
        if (_spawnCount < spermAmount) {
            GameObject sperm = Instantiate(_SpermObject) as GameObject;
            sperm.transform.parent = transform;
            float scale = Random.Range(_maxInstanceScale, _minInstanceScale);
            sperm.transform.localPosition = new Vector3 (0, 0, 0);
            sperm.transform.localScale = new Vector3(scale, scale, scale);
        }
        _spawnCount++;
        
        // for (int i = 0; i < spermAmount; i++)
        // {
        //     GameObject sperm = Instantiate(_SpermObject) as GameObject;
        //     sperm.transform.parent = transform;
        //     float scale = Random.Range(_maxInstanceScale, _minInstanceScale);
        //     sperm.transform.localPosition = new Vector3 (0, 0, 0);
        //     sperm.transform.localScale = new Vector3(scale, scale, scale);
        // }

    }

    void SpawnLastSperm()
    {
        GameObject sperm = Instantiate(_SpermObject) as GameObject;
    //    Debug.Log(sperm);
        
        sperm.transform.parent = transform;
     //   Debug.Log(sperm.transform.parent.gameObject);
        sperm.transform.localPosition = new Vector3(0, 0, 0);
        sperm.transform.localEulerAngles = new Vector3(0, 90, 90);

        if (_levelNumber == 3)
        {
            sperm.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            sperm.transform.Find("Glow").localScale = new Vector3(1.5f, 1.5f, 1.5f);
            sperm.transform.Find("Glow").GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1f);
            sperm.transform.Find("SpermTail").GetComponent<TrailRenderer>().startWidth = 0.03f;
            sperm.transform.Find("SpermTail").GetComponent<TrailRenderer>().time = 2f;
        }

        if (_levelNumber == 1)
        {
            sperm.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        }

        if (_levelNumber == 2)
        {
            sperm.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            ParticleSystem Dandelion = sperm.transform.Find("Dandelion").GetComponent<ParticleSystem>();
            Dandelion.startSize = 2f;
            Dandelion.startSpeed = 0.5f;
            Dandelion.startLifetime = 2f;
            Dandelion.maxParticles = 150;
            Dandelion.emissionRate = 25;
            sperm.transform.Find("Trace").GetComponent<ParticleSystem>().startSize = 0.2f;

            
        }
        
    }

    public void LeftOne()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.GetComponent<SpermLife>().Die();
        }
        StartCoroutine(GenerateFinalSperm());  
    }

    IEnumerator GenerateFinalSperm()
    {
        yield return new WaitForSeconds(2f);
   //     Debug.Log("yay");
        SpawnLastSperm();
    }

}
