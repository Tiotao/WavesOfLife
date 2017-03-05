using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneSelector : MonoBehaviour {

	public Button[] _SceneBtns;
	public AsyncSceneLoader _AsyncSceneLoader;
	private int _sceneIndexOffset = 1;
	

	


	// Use this for initialization
	void Start () {
		for (int i = 0; i < _SceneBtns.Length; i++) {
			int _sceneIndex = i + _sceneIndexOffset;
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
