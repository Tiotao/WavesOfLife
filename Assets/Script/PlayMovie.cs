using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class PlayMovie : MonoBehaviour {
	public float counter=20.0f;
	// Use this for initialization
	void Start () {
        #if UNITY_ANDROID
            Handheld.PlayFullScreenMovie("Sprites/FinalAnimation.mp4");
        #else
            MovieTexture mov;
            mov = (MovieTexture)this.GetComponent<Renderer> ().material.mainTexture;
		    mov.Play ();
        #endif

    }

    // Update is called once per frame
    void Update () {
		counter -= Time.deltaTime;
		if (counter <= 0) {
			SceneManager.LoadScene ("Begin");
		}
	}
}
