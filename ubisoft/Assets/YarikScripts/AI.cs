using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour{
    Robot MyRobot;
    int type;
    int whatToDo;
    IEnumerator DO;
	public LightSetScr LSS;
    
    void Start()
    {
        MyRobot = GetComponent<Robot>();
        StartCoroutine(DoSomesthing());
    }
    IEnumerator DoSomesthing()
    {
        while (true)
        {
            yield return new WaitForSeconds(2.5f);
            //whatToDo = Random.Range(0, 2);
            if (whatToDo == 1) whatToDo = 0;
            else whatToDo = 1;
            type = Random.Range(0, 3);

			if (whatToDo == 0){
                StartCoroutine(MyRobot.Attack(type));
				if (type == 0){
					LSS.SetColor(ColorType.Red,State.Attack);
				}else if (type == 1)
				{
					LSS.SetColor(ColorType.Blue,State.Attack);
				}else if (type == 2)
				{
					LSS.SetColor(ColorType.Green,State.Attack);
				}
			}
			else{
                StartCoroutine(MyRobot.Defend(type));
				if (type == 0){
					LSS.SetColor(ColorType.Red,State.Def);
				}else if (type == 1)
				{
					LSS.SetColor(ColorType.Blue,State.Def);
				}else if (type == 2)
				{
					LSS.SetColor(ColorType.Green,State.Def);
				}
			}
        }
    }
}
