using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour{
    Robot MyRobot;
    int type;
    int whatToDo;
    IEnumerator DO;
    
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
            if (whatToDo == 0)
                StartCoroutine(MyRobot.Attack(type));
            else
                StartCoroutine(MyRobot.Defend(type));
        }
    }
}
