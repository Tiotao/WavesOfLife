using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FishFlowBy : MonoBehaviour
{
    public bool Flow;

    public string _spriteName = "BigFish";

    public string _levelNumber = "1";

    private bool _spriteLoaded = false;
    public List<Sprite> BG;
    private int i = 0;
    private float counter = 1/4 ;
    private float Begin = 0f;
    private bool reverse;
    private float timer = 30.0f;
    // Use this for initialization
    void Start()
    {
        for(int i = 0; i <= 72; i++) {
            StartCoroutine(LoadSpriteFrame(i));
        }
    }

    IEnumerator LoadSpriteFrame(int frame) {
        
        
        string path = "Level" + _levelNumber + "_" + _spriteName + "/" + _spriteName + "_" +frame.ToString("00000");
        ResourceRequest req = Resources.LoadAsync<Sprite>(path);
        
        while(!req.isDone) {
            yield return null;
        }
        
        BG.Add(req.asset as Sprite);
        if (frame >= 72) {
            _spriteLoaded = true;
        }
        
    }

    
    void Update()
    {
        if (Flow)
        {
            timer -= Time.deltaTime;
            this.transform.parent = null;
            this.transform.Translate(new Vector3(0, 1, 0) * 0.07f * Time.deltaTime * 60f);
     
            if(timer<=0)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
    void FixedUpdate()
    {
        if (Flow && _spriteLoaded)
        {
           
           
                counter -= Time.deltaTime;
                if (counter <= 0)
                {

                    if (!reverse)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = BG[i];
                        i++;
                    }
                    else
                    {
                        this.GetComponent<SpriteRenderer>().sprite = BG[i];
                        i--;
                    }
                    counter = 1 /4;

                    if (i >= 72)
                    {
                        reverse = true;
                    }
                    if (i <= 0)
                    {
                        reverse = false;
                    }
                }
            
        }
    }
}
