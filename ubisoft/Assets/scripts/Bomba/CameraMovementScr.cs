using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementScr : MonoBehaviour {
	public Transform CamObj;
	public float SpeedPos;
	public float SpeedRot;

	public bool useLerpPos;
	public bool useLerpRot;
	public Transform lookAt;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (CamObj != null)
		{
			float fps = 1/Time.deltaTime;
			float lerpValPos = Mathf.Clamp01(fps*SpeedPos/200);
			float lerpValRot = Mathf.Clamp01(fps*SpeedRot/200);
			if (useLerpPos){
			transform.position = Vector3.Lerp(transform.position,CamObj.position,lerpValPos);
			}
			else 
			{
				transform.position = CamObj.position;
			}
			if (useLerpRot){
			transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.LookRotation(lookAt.position - transform.position),lerpValRot);
			}else
			{
				transform.rotation = Quaternion.Lerp(transform.rotation,CamObj.rotation,lerpValRot);
			}
		}
	}
}
