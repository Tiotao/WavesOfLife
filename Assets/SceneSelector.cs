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
            int levelIndex = int.Parse(l.ID);
            if (l.Unlocked) {
                int _sceneIndex = levelIndex + _sceneIndexOffset;
                _SceneBtns[levelIndex].gameObject.GetComponent<Image>().sprite = _SceneUnlockBtnsSprite[levelIndex];
                
                _SceneBtns[levelIndex].onClick.AddListener(delegate () { LoadScene(_sceneIndex); });
                iTween.ScaleBy(_SceneBtns[levelIndex].gameObject, new Vector3(1.5f, 1.5f, 1.5f), 1f);
                ScaleUp(_SceneBtns[levelIndex].gameObject);
            } else {
                iTween.ScaleBy(_SceneBtns[levelIndex].gameObject, new Vector3(0.5f, 0.5f, 0.5f), 1f);
                _SceneBtns[levelIndex].gameObject.transform.GetChild(0).gameObject.SetActive(false);
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

    void ScaleUp(GameObject obj) {
		iTween.ScaleAdd(obj, iTween.Hash("amount", new Vector3(0.2f, 0.2f, 0.2f), "oncompletetarget", gameObject, "oncomplete", "ScaleDown", "delay", Random.Range(0, 5), "time", Random.Range(10, 20), "oncompleteparams", obj, "easetype", iTween.EaseType.linear));

    }

    void ScaleDown(GameObject obj) {
		iTween.ScaleAdd(obj, iTween.Hash("amount", new Vector3(-0.2f, -0.2f, -0.2f), "oncompletetarget", gameObject, "oncomplete", "ScaleUp", "delay", Random.Range(0, 5), "time", Random.Range(10, 20), "oncompleteparams", obj, "easetype", iTween.EaseType.linear));

    }

	IEnumerator GoToSelectedScene(int sceneIndex) {
		yield return new WaitForSeconds (3f);
        _AsyncSceneLoader.ToSelectedScene(sceneIndex);
    }

    // The following two functions will maintain level list and set the lock/unlock state of a level.

    // Load Xml file.
    
}


