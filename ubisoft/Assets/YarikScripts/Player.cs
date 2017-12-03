using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    Robot MyRobot;
    public int type;
	public LightSetScr LSS;

	void Start () {
        MyRobot = GetComponent<Robot>();
        type = 1;
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && MyRobot.currentState == Robot.State.Idle)
        {
            StartCoroutine(MyRobot.Attack(type));

        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            StartCoroutine(MyRobot.Defend(type));
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && type > 0)
        {
            type--;
			if (type == 0)
			{
				LSS.SetColor(ColorType.Red,State.Attack);
			}else if (type == 1)
			{
				LSS.SetColor(ColorType.Blue,State.Attack);
			}else if (type == 2)
			{
				LSS.SetColor(ColorType.Green,State.Attack);
			}
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && type < 2)
        {
            type++;
			if (type == 0)
			{
				LSS.SetColor(ColorType.Red,State.Attack);
			}else if (type == 1)
			{
				LSS.SetColor(ColorType.Blue,State.Attack);
			}else if (type == 2)
			{
				LSS.SetColor(ColorType.Green,State.Attack);
			}
        }
    }
}
