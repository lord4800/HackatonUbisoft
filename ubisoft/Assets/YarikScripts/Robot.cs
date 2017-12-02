using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    int HP = 10;
    AudioSource audio;
    [SerializeField] Armor MyArmor;
    [SerializeField] Weapon MyWeapon;
    Animator MyAnimator;
    [SerializeField] Robot Opponent;
    [SerializeField] bool attack;
    [SerializeField] bool block;
    int attackType;
    int defendType;
    [SerializeField] AudioClip deathSound;
    [SerializeField] AudioClip hitSound;
    [SerializeField] AudioClip blockSound;

    enum State { Idle, Attack, Block, BlockReaction, TakeHit };
    [SerializeField] State currentState;

    void Start()
    {
        MyAnimator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }
    void Update()
    {
    }


    public void SetNewOpponent(Robot NewOpponent)
    {
        Opponent = NewOpponent;
    }

    public void StartAttack(int attackType)
    {
        StartCoroutine(Atack(attackType));
    }
    public void StartDefend(int defendType)
    {
        StartCoroutine(Defend(defendType));
    }

    public void TakeHit(int type, int value)
    {
        StartCoroutine(ITakeHit(type, value));
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

    IEnumerator ITakeHit(int type, int value)
    {
        attack = false;
        if (block)
        {
            int damage = value - MyArmor.stats[type];
            audio.PlayOneShot(blockSound, 1);
            MyAnimator.CrossFade("BlockReact", 0.1f);
            currentState = State.BlockReaction;
            if (damage > 0)
            {
                HP -= damage;
                if (HP <= 0) StartCoroutine(Die());
                else yield return new WaitForSeconds(2);
                currentState = State.Idle;
            }
            if (defendType == type)
                Opponent.TakeStun();

        }
        else
        {
            audio.PlayOneShot(hitSound, 1);
            MyAnimator.CrossFade("TakeHit" + type.ToString(), 0.1f);
            HP -= value;
            currentState = State.TakeHit;
            if (HP <= 0) StartCoroutine(Die());
            else
            {
                yield return new WaitForSeconds(2);
                currentState = State.Idle;
            }

        }
    }
    IEnumerator Atack(int attackType)
    {
        if (currentState == State.Idle || currentState == State.Block)
        {
            currentState = State.Attack;
            block = false;
            attack = true;
            MyAnimator.CrossFade("Attack" + attackType.ToString(), 0.1f);
            yield return new WaitForSeconds(1f);
            if (attack)
            {
                Opponent.TakeHit(attackType, MyWeapon.stats[attackType]);
                yield return new WaitForSeconds(1f);
                currentState = State.Idle;
            }
            yield return new WaitForSeconds(1f);
            attack = false;
        }
    }
    IEnumerator Defend(int defendType)
    {
        if (currentState == State.Idle || currentState == State.Block)
        {
            attack = false;
            block = true;
            currentState = State.Block;
            MyAnimator.CrossFade("BlockIdle", 0.1f);
            yield return new WaitForSeconds(2);
            block = false;
            currentState = State.Idle;
        }
    }
    IEnumerator Die()
    {
        MyAnimator.CrossFade("Death", 0.1f);
        audio.PlayOneShot(deathSound, 1);
		yield return new WaitForSeconds (2);
        gameObject.SetActive(false);
    }
}
