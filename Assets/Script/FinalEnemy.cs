using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FinalEnemy : MonoBehaviour {

    bool lastOneGenerated = false;
    public GameObject _SpermGroups;
    public GameObject _BlackOverlay;
	public GameObject LfHand;
	public GameObject RtHand;
    bool _isFading = false;
    bool _isBrightening = false;

    float _fadingDuration = 1f;
    float _brighteningDuration = 3f;
    float t = 0f;

    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void Update() {
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

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !lastOneGenerated)
        {
			LfHand.transform.eulerAngles = new Vector3 (0,0,-108);
			RtHand.transform.eulerAngles = new Vector3 (0,0,-97);
            lastOneGenerated = true;
            _isFading = true;
            _SpermGroups.GetComponent<SpermGroupController>().LeftOne();
        }
    }
}
