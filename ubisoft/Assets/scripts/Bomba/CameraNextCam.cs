using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BombaScr{
	public class CameraNextCam : MonoBehaviour {
		public CameraNextCam NextPos;
		public Transform Tangent1;
		public Transform Tangent2;

		public Transform Robot;
		public bool IsRobot;
		// Use this for initialization
		void Start () {
			
		}
	
		// Update is called once per frame
		void Update () {
			
		}
		void OnDrawGizmos() {
			Gizmos.color = Color.yellow;
			Gizmos.DrawSphere(Tangent1.position, 0.1f);
			Gizmos.color = Color.green;
			Gizmos.DrawSphere(Tangent2.position, 0.1f);
			Gizmos.color = Color.blue;
			for(float i = 0; i < 1; i+=0.05f)
			{
				Gizmos.DrawSphere(GetPoint(transform.position,Tangent2.position,NextPos.Tangent1.position,NextPos.transform.position,i), 0.1f);
				Gizmos.DrawSphere(GetPoint(transform.position,Tangent2.position,NextPos.Tangent1.position,NextPos.transform.position,i), 0.1f);
				Gizmos.DrawSphere(GetPoint(transform.position,Tangent2.position,NextPos.Tangent1.position,NextPos.transform.position,i), 0.1f);
			}
		}

		Vector3 GetPoint (Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t) {
			t = Mathf.Clamp01(t);
			float oneMinusT = 1f - t;
			return
				oneMinusT * oneMinusT * oneMinusT * p0 +
				3f * oneMinusT * oneMinusT * t * p1 +
				3f * oneMinusT * t * t * p2 +
				t * t * t * p3;
		}
	}
}
