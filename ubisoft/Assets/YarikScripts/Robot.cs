using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour {
    int HP = 1000;
    [SerializeField] Armor MyArmor;
    [SerializeField] Weapon MyWeapon;
    Animator MyAnimator;
    [SerializeField] Robot Opponent;
    bool attack;
    bool block;
    int attackType;
    int defendType;

    enum State {Idle, Attack, Block, BlockReaction, TakeHit };
    State currentState;

    void Start() {
        MyAnimator = GetComponent<Animator>();
	}
	void Update () {		
	}
    

    public void SetNewOpponent(Robot NewOpponent)
    {
        Opponent = NewOpponent;
    }
    
    public void StartAttack(int attackType)
    {
        currentState = State.Attack;
        block = false;
        attack = true;
        MyAnimator.CrossFade("Attack" + attackType.ToString(), 0.1f);

        StartCoroutine(WaitAndHit());

    }
    public void StartDefend(int defendType)
    {
        attack = false;
        block = true;
        MyAnimator.CrossFade("BlockIdle", 0.1f);
    }
    
    public void TakeHit(int type, int value)
    {
        //
        attack = false;
        if (block)
        {
            int damage = value - MyArmor.stats[type];
            if (damage > 0)
            {
                MyAnimator.CrossFade("BlockReact", 0.1f);
                HP -= damage;
                if (HP <= 0) Die();
            }
            if (defendType == type)
                Opponent.TakeStun();
        }
        else
        {
            MyAnimator.CrossFade("TakeHit" + type.ToString(), 0.1f);
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


    IEnumerator WaitAndHit()
    {
        yield return new WaitForSeconds(0.8f);
        if (attack)
            Opponent.TakeHit(attackType, MyWeapon.stats[attackType]);
    }
}
