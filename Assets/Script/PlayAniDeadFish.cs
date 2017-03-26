using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayAniDeadFish : MonoBehaviour
{
    public List<Sprite> BG;
    public SpermGroupController _player;
    public string _spriteName = "DeadFish";

    public string _levelNumber = "1";
    public int _frameNumber = 45;
    public int _frameRate = 6;
    public float Begin = 0f;
    private int i = 0;
    private float counter;
    public bool startplay;
    private bool set;

    public bool _spriteLoaded = false;
    // Use this for initialization
    void Start()
    {
        for(int i = 0; i <= _frameNumber; i++) {
            StartCoroutine(LoadSpriteFrame(i));
        }
        counter = 1 / _frameRate;
        this.GetComponent<SpriteRenderer>().sprite = null;
    }

    IEnumerator LoadSpriteFrame(int frame) {
        
        // string path = _spriteFolderName + "/endFIsh_"  +frame.ToString("00000");
        string path = "Level" + _levelNumber + "_" + _spriteName + "/" + _spriteName + "_" +frame.ToString("00000");
        ResourceRequest req = Resources.LoadAsync<Sprite>(path);
        
        while(!req.isDone) {
            yield return null;
        }
        
        BG.Add(req.asset as Sprite);
        if (frame >= _frameNumber) {
            _spriteLoaded = true;
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        if (startplay && _spriteLoaded)
        {
            if (Begin > 0)
                Begin -= Time.deltaTime;
            if (Begin <= 0)
            {
                if (!set)
                {
                    this.GetComponent<Animator>().SetTrigger("Eat");
                    set = true;
                }
                counter -= Time.deltaTime;
                if (counter <= 0)
                {
                    if (i < BG.Count)
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
}
