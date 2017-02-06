using UnityEngine;
using System.Collections;

public class PlayerNear : MonoBehaviour {
    public Sprite Open;
    public Sprite Close;
    private SpriteRenderer _render;
	// Use this for initialization
	void Start () {
        _render = this.GetComponent<SpriteRenderer>();

    }
	
	// Update is called once per frame
	void Update () {
	
	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            _render.sprite = Open;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _render.sprite = Close;
        }
    }
}
