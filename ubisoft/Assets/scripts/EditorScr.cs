using UnityEngine;
//using UnityEditor;
using System.Collections.Generic;

/// <summary>
/// Editor script wich create inspector stuff.
/// </summary>
namespace WayPointVelcroGames{
public class EditorScr : MonoBehaviour {

	public Transform mainCam;
	public GameObject AimArrow;
	List <GameObject> Sprites;

	//TODO look at camera;

	//[MenuItem ("WayPoints/DrawNodes")]

	[ContextMenu("SeeStuff")] 
	public void seeStuf()
		{
		if (!GameObject.FindGameObjectWithTag ("Arrow")) {
			GameObject[] Nodes = GameObject.FindGameObjectsWithTag ("WayNode");
			foreach (GameObject node in Nodes) {
				Instantiate (AimArrow, node.transform, false);
				//Sprites.Add ();
			}
		}

	}

	//TODO make this work on play button;
	//[MenuItem ("WayPoints/DrawNodes")]



	[ContextMenu("UnseeStuff")] 
	private void unseeStuf()
	{
		GameObject[] Nodes = GameObject.FindGameObjectsWithTag ("Arrow");
		foreach (GameObject node in Nodes)
		{
			DestroyImmediate (node);
		}
	}

}
}