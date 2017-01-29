using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class PlayMovie : MonoBehaviour {
	public float counter=20.0f;
	// Use this for initialization
	void Start () {
		MovieTexture mov;

		mov = (MovieTexture)this.GetComponent<Renderer> ().material.mainTexture;
		mov.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		counter -= Time.deltaTime;
		if (counter <= 0) {
			SceneManager.LoadScene ("Begin");
		}
	}
}
