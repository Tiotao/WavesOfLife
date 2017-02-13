using UnityEngine;
using System.Collections;

public class SpritesAnimation : MonoBehaviour {

    public Sprite[] BG;
    public string _spriteFolderName = "level1_animation";
    public int _frameNumber = 45;
    public int _frameRate = 12;
    public float Begin = 0f;
    private int i = 0;
    private float counter;
    private bool set;
    //  private float Begin = 39.0f;
    
    private bool reverse;
    // Use this for initialization
    void Start()
    {
        BG = Resources.LoadAll<Sprite>(_spriteFolderName);
        counter = 1 / _frameRate;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Begin > 0)
            Begin -= Time.deltaTime;
        if (Begin <= 0)
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
                counter = 1 / _frameRate;

                if (i >= _frameNumber)
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
