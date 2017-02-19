using UnityEngine;
using System.Collections;

public class PlayAniDeadFish : MonoBehaviour
{
    public Sprite[] BG;
    public SpermGroupController _player;
    public string _spriteFolderName = "lvl1_deadfish";
    public int _frameNumber = 45;
    public int _frameRate = 6;
    public float Begin = 0f;
    private int i = 0;
    private float counter;
    public bool startplay;
    private bool set;
    // Use this for initialization
    void Start()
    {
        BG = Resources.LoadAll<Sprite>(_spriteFolderName);
        counter = 1 / _frameRate;
        this.GetComponent<SpriteRenderer>().sprite = null;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        if (startplay)
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
}
