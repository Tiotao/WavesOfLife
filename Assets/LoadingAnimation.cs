using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingAnimation : MonoBehaviour {

	// Use this for initialization

	void Start () {
		StartCoroutine(LoadingScene());
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	IEnumerator LoadingScene() {
		AsyncOperation ao = SceneManager.LoadSceneAsync(1);
		ao.allowSceneActivation = false;
		while (ao.progress < 0.9f) {
			yield return null;
		}
		yield return new WaitForSeconds(2f);
		ao.allowSceneActivation = true;
		//Destroy(this.gameObject);
	}
}
