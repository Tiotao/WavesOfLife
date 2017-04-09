using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform targetPosition;
	public float smoothtime = 0.3f;

	Vector3 offset;
	float AngleOffset;
	private Vector3 velocity = Vector3.zero;
    Vector3 targetCamPosition;
    // Use this for initialization
    void Start () {
		offset = transform.position - targetPosition.position;
	//	AngleOffset = transform.eulerAngles.z - targetPosition.eulerAngles.x;
	}

	// Update is called once per frame
	void Update () {
       // Debug.Log(offset.y);
       if(Mathf.Abs(offset.x)>Mathf.Abs(offset.y))
            targetCamPosition = targetPosition.position +  (offset.x)*targetPosition.forward;
       else
            targetCamPosition = targetPosition.position + (offset.y) * targetPosition.forward;
        targetCamPosition.z = this.transform.position.z;
	//	Vector3 targetCamEu = transform.eulerAngles;
	//	targetCamEu.z = AngleOffset + targetPosition.eulerAngles.x-transform.eulerAngles.z;
		// smoothdamp the camera movement
		transform.position = Vector3.SmoothDamp(transform.position, targetCamPosition, ref velocity, smoothtime);
		//transform.eulerAngles = Vector3.SmoothDamp (transform.eulerAngles, targetCamEu, ref velocity, smoothtime);
		//Debug.Log(targetCamEu.y);
	//	this.transform.Rotate(targetCamEu);
	}
}
