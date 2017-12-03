using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitFadeScr : MonoBehaviour {
	public Image img;
	public float FadeTime;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void hit ()
	{
		StartCoroutine (Fade());
	}

	IEnumerator Fade()
	{
		for (float i = 0; i < FadeTime/2; i += Time.deltaTime)
		{
			yield return new WaitForSeconds(Time.deltaTime);
			img.color = new Color(255,255,255,i/(FadeTime/2));
		}
		for (float i = 0; i < FadeTime/2; i += Time.deltaTime)
		{
			yield return new WaitForSeconds(Time.deltaTime);
			img.color = new Color(255,255,255,1 - i/(FadeTime/2));
		}
	}
}
