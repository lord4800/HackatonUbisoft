using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    Robot MyRobot;


	void Start () {
        MyRobot = GetComponent<Robot>();
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //MyRobot.StartAttack();
        }
    }
}
