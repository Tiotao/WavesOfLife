using UnityEngine;
using System.Collections;

public class Lvl1EndingAnimation : MonoBehaviour {
    public GameObject Light;
    public GameObject _camera;
    public float _Time;
    private float timer=0;
    public GameObject _Map;
    public GameObject Mask;
    public GameObject Glow;
    public GameObject[] FlowBugs;

    public FadeInWhenBeginning _BlackOverlay;

    public AsyncSceneLoader _AsyncSceneLoader;

    

    bool _startFading = false;
	// Use this for initialization
	void Start () {
        _Map.SetActive(false);
        Light.GetComponent<SpritesAnimation>().Begin = 0f;
        Mask.SetActive(true);
        Glow.SetActive(true);
        Camera.main.GetComponent<WaterCameraEffect>().enabled = false;
        for(int i=0;i<FlowBugs.Length;i++)
        {
            FlowBugs[i].GetComponent<FlowBugsMove>().BeginMove = true;
        }
        LevelAccess.SetLevel("1", true);
        StartCoroutine(FadingToNextScene());
    }

    IEnumerator FadingToNextScene() {
        yield return new WaitForSeconds(_Time);
        _camera.GetComponent<CameraFollow>().enabled = false;
        _AsyncSceneLoader.ToSelectedScene(2);
        
    }
	
	// Update is called once per frame
	
}
