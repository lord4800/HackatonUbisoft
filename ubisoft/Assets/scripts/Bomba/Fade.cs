using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BombaScr{
	public class Fade : MonoBehaviour {
		public float FadeTime;
		public SpriteRenderer Sp;

		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
			
		}

		IEnumerator Stay ()
		{
			yield return new WaitForSeconds(0);
			for(float i = 0; i<1;i+=Time.deltaTime )
			{
				Sp.color = new Color(0,0,0,i/FadeTime);
			}
		}
	}
}
