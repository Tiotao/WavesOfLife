using UnityEngine;
using System.Collections;

public class FishFlowBy : MonoBehaviour
{
    public bool Flow;
    public Sprite[] BG;
    private int i = 0;
    private float counter = 1 / 12;
    private float Begin = 0f;
    private bool reverse;
    // Use this for initialization
    void Start()
    {
        BG = Resources.LoadAll<Sprite>("BigFish");
    }

    // Update is called once per frame
    void Update()
    {
        if (Flow)
        {
            this.transform.Translate(new Vector3(0, 1, 0) * 0.04f * Time.deltaTime * 60f);
        }
    }
    void FixedUpdate()
    {
        if (Flow)
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
                    counter = 1 / 12;

                    if (i >= 45)
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
