using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    Robot MyRobot;
    int type;

	void Start () {
        MyRobot = GetComponent<Robot>();
        type = 1;
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MyRobot.StartAttack(type);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MyRobot.StartDefend(type);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && type > 0)
        {
            type--;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && type < 2)
        {
            type++;
        }
    }
}
