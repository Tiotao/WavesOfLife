using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneSelector : MonoBehaviour {

	public Button[] _SceneBtns;

	public Sprite[] _SceneUnlockBtnsSprite;
	public AsyncSceneLoader _AsyncSceneLoader;
	private int _sceneIndexOffset = 1;
	
	// public int _maxLevel = 2;


	// Use this for initialization
	void Start () {
		
        List<Level> levels = LevelAccess.LoadLevels();

        foreach(Level l in levels) {
            
            if (l.Unlocked) {
                int levelIndex = int.Parse(l.ID);
                int _sceneIndex = levelIndex + _sceneIndexOffset;
                _SceneBtns[levelIndex].gameObject.GetComponent<Image>().sprite = _SceneUnlockBtnsSprite[levelIndex];
                _SceneBtns[levelIndex].onClick.AddListener(delegate () { LoadScene(_sceneIndex); });
            }
        }
        //SetLevel("1", true);
		
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

    // The following two functions will maintain level list and set the lock/unlock state of a level.

    // Load Xml file.
    
}


