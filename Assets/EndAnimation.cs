using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndAnimation : MonoBehaviour {

    public Sprite[] BG;
    public string _spriteFolderName = "lvl1_deadfish";
    public int _frameNumber = 45;
    public int _frameRate = 6;
    private int i = 0;
    private float counter;
    public bool startplay;
    // Use this for initialization
    void Start()
    {
        BG = Resources.LoadAll<Sprite>(_spriteFolderName);
        counter = 1 / _frameRate;
     
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        if (startplay)
        { 
                counter -= Time.deltaTime;
                if (counter <= 0)
                {
                    if (i < BG.Length)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = BG[i];
                        i++;
                        counter = 1f / _frameRate;
                        //    Debug.Log(i);
                    }
                    else
                    {
                        this.enabled = false;
                    }
                }
            
        }
    }
}
