using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotManagerScr : MonoBehaviour {
	public AI ai;
	public BombaScr.CameraScr CS;
	public Robot r;
	// Use this for initialization
	void Start () {
		r = GetComponent<Robot>();
		ai = GetComponent<AI>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartFight()
	{
		ai.enabled = true;
		CS.Hero.SetNewOpponent(r);
	
	}

	public void StopFight()
	{
		ai.enabled = false;
		CS.MoveNext();
	}
}
