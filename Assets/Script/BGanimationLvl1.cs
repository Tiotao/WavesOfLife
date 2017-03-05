using UnityEngine;
using System.Collections;

public class BGanimationLvl1 : MonoBehaviour {
    public Sprite[] BG;
    private int i = 0;
    private float counter = 1 / 12;
  //  private float Begin = 39.0f;
      private float Begin = 0f;
    private bool reverse;
    // Use this for initialization
    void Start()
    {
        BG = Resources.LoadAll<Sprite>("level1_animation");
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
