using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneSelector : MonoBehaviour {

	public Button[] _SceneBtns;

	public Sprite[] _SceneUnlockBtnsSprite;
	public AsyncSceneLoader _AsyncSceneLoader;
	private int _sceneIndexOffset = 1;
	

	public int _maxLevel = 2;


	// Use this for initialization
	void Start () {
		
		for (int i = 0; i < _maxLevel; i++) {
			int _sceneIndex = i + _sceneIndexOffset;
			_SceneBtns[i].gameObject.GetComponent<Image>().sprite = _SceneUnlockBtnsSprite[i];
			_SceneBtns[i].onClick.AddListener(delegate () { LoadScene(_sceneIndex); });
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void LoadScene(int sceneIndex) {
		
		_AsyncSceneLoader.ToSelectedScene(sceneIndex);
	}

	IEnumerator GoToSelectedScene(int sceneIndex) {
		yield return new WaitForSeconds (3f);
        _AsyncSceneLoader.ToSelectedScene(sceneIndex);
    }
}
