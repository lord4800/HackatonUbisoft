using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour {
    int HP;
    [SerializeField] Armor MyArmor;
    [SerializeField] Weapon MyWeapon;
    Robot Opponent;
    bool doAttack;
    bool doDefend;
    int attackType;
    int defendType;

    void Start () {		
	}
	void Update () {		
	}
    

    public void SetNewOpponent(Robot NewOpponent)
    {
        Opponent = NewOpponent;
    }
    
    public void StartAttack(int attackType)
    {
        doDefend = false;
        doAttack = true;
    }
    public void StartDefend(int defendType)
    {
        doAttack = false;
        doDefend = true;
    }
    void MakeHit()
    {
        //
        Opponent.TakeHit(attackType, MyWeapon.stats[attackType]);
    }
    public void TakeHit(int type, int value)
    {
        //
        if (doDefend)
        {
            int damage = value - MyArmor.stats[type];
            if (damage > 0)
            {
                HP -= damage;
                if (HP <= 0) Die();
            }
            if (defendType == type)
                Opponent.TakeStun();
        }
        else
        {
            HP -= value;
            if (HP <= 0) Die();
        }
    }
    public void TakeStun()
    {
        //
    }

    public void NewArmor(Armor NewArmor)
    {
        MyArmor = NewArmor;
    }
    public void NewWeapon(Weapon NewWeapon)
    {
        MyWeapon = NewWeapon;
    }

    public void Die()
    {
        //
    }

}
