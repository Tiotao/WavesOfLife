using UnityEngine;
using System.Collections;

public class ParticleControl : MonoBehaviour {

    ParticleSystem ps;
    public float startNo =30;
    public float NewNo=15;
    public bool startlerp=false;

    

	// Use this for initialization
	void Start () {
        ps = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
       // if (!startlerp) {
            if (startNo -NewNo >= .2f || startNo - NewNo <= -.2f) {
               // startlerp = false;
                startNo = Mathf.Lerp(startNo, NewNo, 1.5f*Time.deltaTime);
                
            } else {
               // startlerp = true;
             NewNo = Random.Range(5f, 75f);
        }

       // }

        var rates = startNo;
        var emission = ps.emission;
        emission.rate = rates;
        

       

	}






}
