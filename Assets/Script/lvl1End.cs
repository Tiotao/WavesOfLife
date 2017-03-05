using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class lvl1End : MonoBehaviour {
    public GameObject _player;
    public GameObject finalFish;
    public GameObject Jelly;
    public GameObject _BlackOverlay;

    bool _isFading = false;
    bool _isBrightening = false;

    float _fadingDuration = 1f;
    float _brighteningDuration = 3f;
    float t = 0f;
    // Use this for initialization
    void Start () {
        iTween.FadeTo(finalFish, 0f, 0f);
    }
	
	// Update is called once per frame
	void Update () {
        if (_isFading && t <= _fadingDuration)
        {
            t = t + Time.deltaTime;
            float intensity = Mathf.Lerp(0f, 1f, t);
            // _camera.GetComponent<Camera>
            _BlackOverlay.GetComponent<Image>().color = new Color(0, 0, 0, intensity);
        }

        if (t > _fadingDuration && _isFading)
        {
            t = t + Time.deltaTime;

        }

        if (t > _fadingDuration + 3f && _isFading)
        {
            _isFading = false;
            _isBrightening = true;
            t = 0f;
        }

        if (_isBrightening && t <= _brighteningDuration)
        {
            t = t + Time.deltaTime;
            float intensity = Mathf.Lerp(1f, 0f, t);
            _BlackOverlay.GetComponent<Image>().color = new Color(0, 0, 0, intensity);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            _player.GetComponent<AutoMove>().lvl1End = true;
            iTween.FadeTo(finalFish, 1f, 0.5f);
            finalFish.GetComponent<PlayAniDeadFish>().startplay = true;
            iTween.FadeTo(Jelly.transform.Find("GlowPointSprite").gameObject, 0f, 0.5f);
            // Jelly.SetActive(false);

            Invoke("StartMove", 1f);
            Invoke("DeleteFish", 4f);
            StartCoroutine(StartFading());
           
        }
    }

    IEnumerator StartFading()
    {
        yield return new WaitForSeconds(3f);
        Invoke("StartEndingAni", 2f);
        _isFading = true;
    }
    private void StartMove()
    {
        finalFish.GetComponent<CapsuleCollider>().enabled = false;
        _player.GetComponentInChildren<SpermGroupController>().LeftOne();
        _player.GetComponent<AutoMove>().lvl1End = false;
        _player.GetComponent<AutoMove>().END = true;

    }
    private void DeleteFish()
    {
        finalFish.SetActive(false);
    }
    private void StartEndingAni()
    {
        this.GetComponent<Lvl1EndingAnimation>().enabled = true;
    }
}
