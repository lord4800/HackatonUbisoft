using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BombaScr{
public class CameraScr : MonoBehaviour {
		public Transform MainCam;
		public Transform NextCamPos;
		[Range(0,2)]
		public float Speed;
		public enum PlayerState
		{
			move,
			fight,
			lootbox
		}
		public enum CamMoveStyle 
		{
			First,
			Second
		}
		public CamMoveStyle moveStyle;
		public PlayerState playerState;
		Vector3 pos;
		Quaternion rot;
		float Distance;
		// Use this for initialization
		void Start () {
			playerState = PlayerState.move;
			if (NextCamPos == null)
			{
				Debug.LogError("Send Cam on CamScript");
			}else 
			{
				Distance = Vector3.Distance(MainCam.position,NextCamPos.position);
				pos = MainCam.position;
				rot = MainCam.rotation;
			}
		}
		float t = 0;
		// Update is called once per frame
		void Update () {
			if (playerState == PlayerState.move)
			{
				if (moveStyle == CamMoveStyle.First)
				{
					float curDist = Vector3.Distance(MainCam.position,NextCamPos.position); 

					t += Time.deltaTime*Speed;//1-curDist/Distance;
					MainCam.position = Vector3.Lerp(pos,NextCamPos.position,t);
					MainCam.rotation = Quaternion.Lerp(rot,NextCamPos.rotation,t);
					if (curDist<0.1f)
					{
						playerState = PlayerState.move;
						pos = MainCam.position;
						rot = MainCam.rotation;
						t = 0;
						//SomeStuff for next link;
					}
				}else if (moveStyle == CamMoveStyle.Second)
				{
					float curDist = Vector3.Distance(MainCam.position,NextCamPos.position); 
					t += Time.deltaTime*Speed;//1-curDist/Distance;
					MainCam.position = Vector3.Lerp(MainCam.position,NextCamPos.position,t);
					MainCam.rotation = Quaternion.Lerp(MainCam.rotation,NextCamPos.rotation,t);
					if (curDist<0.1f)
					{
						playerState = PlayerState.move;
						pos = MainCam.position;
						rot = MainCam.rotation;
						t= 0;
						//SomeStuff for next link;
					}
				}
			}
		}
	}
}
