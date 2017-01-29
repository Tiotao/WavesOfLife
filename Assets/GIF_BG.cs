using UnityEngine;
using System.Collections;

public class GIF_BG : MonoBehaviour {
	public Sprite[] BG;
	private int i=0;
	private float counter = 1 / 12;
	private float Begin = 39.0f;
	// Use this for initialization
	void Start () {
		BG = Resources.LoadAll<Sprite> ("BGanimation");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Begin>0)
		Begin -= Time.deltaTime;
		if (Begin <= 0) {
			counter -= Time.deltaTime;
			if (counter <= 0) {
			
				this.GetComponent<SpriteRenderer> ().sprite = BG [i];
				i++;
				counter = 1 / 12;
				if (i >= 90) {
					i = 0;
				}
			}
		}
	}
}
