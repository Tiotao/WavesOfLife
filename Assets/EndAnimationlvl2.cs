using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndAnimationlvl2 : MonoBehaviour {
    public GameObject SnakeHead;
    public GameObject Startposition;
    public GameObject Player;
    public GameObject cam;
    public bool automove;
    public GameObject LeafGroup;

    public SpermGroupController _player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(automove)
        {
            Player.transform.Translate(new Vector3(0, 0, 1) * 0.04f * Time.deltaTime * 60f);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            SnakeHead.GetComponent<SpritesAnimation>().Begin = -1;
            LeafGroup.GetComponent<Animator>().SetTrigger("PlayAni");
            GameObject.FindGameObjectWithTag("Player").GetComponent<AutoMove>().lvl1End = true;
            Invoke("AfterEndAni", 2.0f);
            _player.LeftOne();
        }
    }
    private void AfterEndAni()
    {
        Player.transform.position = Startposition.transform.position;
        cam.transform.eulerAngles = new Vector3(0, 0, -90f);
        Player.transform.eulerAngles = new Vector3(-180f, -90f, 0);
        automove = true;
    }



}
