using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableOnStart : MonoBehaviour {

	[SerializeField]
	GameObject[] listToEnables;
	// Use this for initialization
	void Start () {
		foreach (GameObject g in listToEnables) {
			if (g != null) {
				Debug.Log ("SetActive " + g.name);
				g.SetActive (true);
			}
		}
	}
}
