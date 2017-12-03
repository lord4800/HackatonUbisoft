using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSetScr : MonoBehaviour {

	public Light[] lights;
	public Material mat;
	//public Renderer rend;
	public bool Hero;
	public Material matHero;
	public float timeChange;
	public ColorType CurrentColor;

	public void SetColor(ColorType newColor,State Def)
	{
		if (newColor == ColorType.White)
		{
			mat.SetColor("_Emissioncolor",new Color(1,1,1,1));
			//rend.material.SetInt();
			foreach (var l in lights)
			{
				l.color = new Color(1,1,1,1);
			}
		}else 
		{
			StartCoroutine(SlowColor(newColor));
		}
	}

	IEnumerator SlowColor(ColorType newColor)
	{
		float cuurentR, currentG, currentB;
		for (float i = 0; i< timeChange/2; i += Time.deltaTime){
			yield return new WaitForSeconds(Time.deltaTime);
		if (CurrentColor == ColorType.Red) 
		{
				mat.SetColor("_Emissioncolor",new Color(1-i/(timeChange/2),0,0,1));
				if (Hero)
					matHero.SetColor("_Color",new Color(1-i/(timeChange/2),0,0,1));
				//rend.material.SetInt();
				foreach (var l in lights)
				{
					l.color = new Color(1-i/(timeChange/2),0,0,1);
				}
		}else if (CurrentColor == ColorType.Blue) 
		{
				mat.SetColor("_Emissioncolor",new Color(0,0,1-i/(timeChange/2),1));
				if (Hero)
					matHero.SetColor("_Color",new Color(0,0,1-i/(timeChange/2),1));
				//rend.material.SetInt();
				foreach (var l in lights)
				{
					l.color = new Color(0,0,1-i/(timeChange/2),1);
				}
		}else if (CurrentColor == ColorType.Green) 
		{
				mat.SetColor("_Emissioncolor",new Color(0,1-i/(timeChange/2),0,1));
				if (Hero)
					matHero.SetColor("_Color",new Color(0,1-i/(timeChange/2),0,1));
				//rend.material.SetInt();
				foreach (var l in lights)
				{
					l.color = new Color(0,1-i/(timeChange/2),0,1);
				}
		}
		}
		for (float i = 0; i< timeChange/2; i += Time.deltaTime){
			yield return new WaitForSeconds(Time.deltaTime);
		if (newColor == ColorType.White)
		{
				mat.SetColor("_Emissioncolor",new Color(1,1,1,1));
				if (Hero)
					matHero.SetColor("_Color",new Color(1,1,1,1));
				//rend.material.SetInt();
				foreach (var l in lights)
				{
					l.color = new Color(1,1,1,1);
				}
				break;
		}else if (newColor == ColorType.Red) 
		{
				mat.SetColor("_Emissioncolor",new Color(i/(timeChange/2),0,0,1));
				if (Hero)
					matHero.SetColor("_Color",new Color(i/(timeChange/2),0,0,1));
				//rend.material.SetInt();
				foreach (var l in lights)
				{
					l.color = new Color(i/(timeChange/2),0,0,1);
				}
				CurrentColor = ColorType.Red;
		}else if (newColor == ColorType.Blue) 
		{
				mat.SetColor("_Emissioncolor",new Color(0,0,i/(timeChange/2),1));
				if (Hero)
					matHero.SetColor("_Color",new Color(0,0,i/(timeChange/2),1));
				//rend.material.SetInt();
				foreach (var l in lights)
				{
					l.color = new Color(0,0,i/(timeChange/2),1);
				}
				CurrentColor = ColorType.Blue;
		}else if (newColor == ColorType.Green) 
		{
				mat.SetColor("_Emissioncolor",new Color(0,i/(timeChange/2),0,1));
				if (Hero)
					matHero.SetColor("_Color",new Color(0,i/(timeChange/2),0,1));
				//rend.material.SetInt();
				foreach (var l in lights)
				{
					l.color = new Color(0,i/(timeChange/2),0,1);
				}
				CurrentColor = ColorType.Green;
		}
		}

	}
	// Use this for initialization
	void Start () {
		if (!Hero)
		{
		SetColor (ColorType.White,State.Idle);
		}else {
			SetColor (ColorType.Blue,State.Idle);
		}
	}
	
	/*// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.C))
		{
			if (CurrentColor == ColorType.White)
			{
				SetColor(ColorType.Red,State.Idle);
			}else if (CurrentColor == ColorType.Red) 
			{
				SetColor(ColorType.Blue,State.Idle);	
			}else if (CurrentColor == ColorType.Blue) 
			{
				SetColor(ColorType.Green,State.Idle);
			}else if (CurrentColor == ColorType.Green) 
			{
				SetColor(ColorType.Red,State.Idle);
			}
		}
	}*/

}
public enum ColorType
{
	Red,
	Green,
	Blue,
	White
}
public enum State {
	Attack,
	Def,
	Idle
}
