using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnStart : MonoBehaviour {
	// Use this for initialization
	public bool CamEnable;
	void Start () {
		if (!CamEnable){
		gameObject.SetActive(false);
		}else 
		{
			GetComponent<Camera>().enabled = false;
		}
		this.enabled = false;

	}
	public void DestroyYourself()
	{
		DestroyImmediate (this);
	}
}
