using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BombaScr{
public class CameraScr : MonoBehaviour {
		public int CurrentLevelCountEquip;
		public int CurrentLevel;
		public Transform MainCam;
		public CameraNextCam NextCamPos;
		[Range(0,2)]
		public float Speed;

		public CameraMovementScr CMS;
		public enum PlayerState
		{
			move,
			fight,
			lootbox
		}
		public enum CamMoveStyle 
		{
			First,
			Second,
			Third
		}
		public Robot Hero;
		public CamMoveStyle moveStyle;
		public PlayerState playerState;
		public string[] Scenes;
		Vector3 pos;
		Quaternion rot;
		Vector3 Tangent2;
		Fade fade;
		float Distance;
		// Use this for initialization
		void Start () {
			fade = GetComponent<Fade>();
			CurrentLevel = PlayerPrefs.GetInt("Level");
			playerState = PlayerState.move;
			if (NextCamPos == null)
			{
				Debug.LogError("Send Cam on CamScript");
			}else 
			{
				Distance = Vector3.Distance(MainCam.position,NextCamPos.transform.position);
				CMS.lookAt = NextCamPos.Robot;
				pos = MainCam.position;
				rot = MainCam.rotation;
				Tangent2 = MainCam.position;
			}
		}
		float t = 0;
		Vector3 GetPoint (Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t) {
			t = Mathf.Clamp01(t);
			float oneMinusT = 1f - t;
			return
				oneMinusT * oneMinusT * oneMinusT * p0 +
				3f * oneMinusT * oneMinusT * t * p1 +
				3f * oneMinusT * t * t * p2 +
				t * t * t * p3;
		}
		float x;
		// Update is called once per frame
		void Update () {
			if (playerState == PlayerState.move)
			{
				if (moveStyle == CamMoveStyle.First)
				{
					float curDist = Vector3.Distance(MainCam.position,NextCamPos.transform.position); 

					t += Time.deltaTime*Speed;//1-curDist/Distance;
					MainCam.position = Vector3.Lerp(pos,NextCamPos.transform.position,t);
					MainCam.rotation = Quaternion.Lerp(rot,NextCamPos.transform.rotation,t);
					if (curDist<0.001f)
					{
						if (NextCamPos.IsRobot){
						playerState = PlayerState.fight;
							if (NextCamPos.RotateRobotLeft )
							{NextCamPos.RMS.TurnLeft();}else if (NextCamPos.RotateRobotLeft){NextCamPos.RMS.TurnRight();}
						NextCamPos.RMS.StartFight();
						}
						//SomeStuff for next link;
					}
				}else if (moveStyle == CamMoveStyle.Second)
				{
					float curDist = Vector3.Distance(MainCam.position,NextCamPos.transform.position); 
					t += Time.deltaTime*Speed;//1-curDist/Distance;
					MainCam.position = Vector3.Lerp(MainCam.position,NextCamPos.transform.position,t);
					MainCam.rotation = Quaternion.Lerp(MainCam.rotation,NextCamPos.transform.rotation,t);
					if (curDist<0.1f)
					{
						if (NextCamPos.RotateRobotLeft )
						{Debug.Log ("Stuff");NextCamPos.RMS.TurnLeft();}else if (NextCamPos.RotateRobotRight){NextCamPos.RMS.TurnRight();}
						if (NextCamPos.IsRobot){
						playerState = PlayerState.fight;
						NextCamPos.RMS.StartFight();
						}else if (!NextCamPos.isFinal)
						{
							
						}
						//SomeStuff for next link;
					}
				}else if (moveStyle == CamMoveStyle.Third)
				{
					float curDist = Vector3.Distance(MainCam.position,NextCamPos.transform.position); 
					//t += Time.deltaTime*Speed;//1-curDist/Distance;
					t+=0.01f;
					x+=Time.deltaTime*Speed;
					MainCam.position = Vector3.Lerp(MainCam.position, GetPoint(pos,Tangent2,NextCamPos.Tangent1.position,NextCamPos.transform.position,t),x);
					//MainCam.position = Vector3.Lerp(MainCam.position,NextCamPos.transform.position,t);
					//MainCam.rotation = Quaternion.Lerp(MainCam.rotation,NextCamPos.transform.rotation,x);
					MainCam.rotation = Quaternion.Lerp(MainCam.rotation,Quaternion.LookRotation(NextCamPos.Robot.position-MainCam.position+Vector3.up*0.2f),x);
					if (curDist<0.1f)
					{
						if (NextCamPos.RotateRobotLeft )
						{NextCamPos.RMS.TurnLeft();}else if (NextCamPos.RotateRobotLeft){NextCamPos.RMS.TurnRight();}
						if (NextCamPos.IsRobot){
						playerState = PlayerState.fight;
						if (NextCamPos.RMS != null){
							NextCamPos.RMS.StartFight();
						}else 
						{
							NextCamPos.RMS = NextCamPos	.GetComponent<RobotManagerScr>();
							NextCamPos.RMS.StartFight();
						}
						}else if (NextCamPos.isFinal) 
						{
							//Fade
							fade.FadeNow();

						}else
						{
							NextCamPos.Work = true;
						}
						//SomeStuff for next link;
					}
				}

			}else if (playerState == PlayerState.fight)
			{
				
			}
		}
		public void MoveNext() 
		{
			if (moveStyle == CamMoveStyle.First)
			{
				NextCamPos = NextCamPos.NextPos;
				CMS.lookAt = NextCamPos.Robot;
				pos = MainCam.position;
				rot = MainCam.rotation;
				t = 0;
				playerState = PlayerState.move;
			}else if (moveStyle == CamMoveStyle.Second)
			{
				NextCamPos = NextCamPos.NextPos;
				CMS.lookAt = NextCamPos.Robot;
				pos = MainCam.position;
				rot = MainCam.rotation;
				t= 0;
				playerState = PlayerState.move;
			}else if (moveStyle == CamMoveStyle.Third)
			{
				Tangent2 = NextCamPos.Tangent2.position;
				NextCamPos = NextCamPos.NextPos;
				CMS.lookAt = NextCamPos.Robot;
				pos = MainCam.position;
				rot = MainCam.rotation;
				t = 0;
				x = 0;
				playerState = PlayerState.move;
			}
		}
	}
}
