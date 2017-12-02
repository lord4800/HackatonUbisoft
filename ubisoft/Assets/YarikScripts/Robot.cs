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
    int attackType;
    int defendType;
    [SerializeField] AudioClip deathSound;
    [SerializeField] AudioClip hitSound;
    [SerializeField] AudioClip blockSound;

    public enum State { Idle, Attack, Block, BlockReaction, TakeHit };
    public State currentState;

    void Start()
    {
        MyAnimator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }


    public void SetNewOpponent(Robot NewOpponent)
    {
        Opponent = NewOpponent;
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

    
    public IEnumerator TakeHit(int type, int value)
    {
        if (currentState == State.Block)
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
                MyAnimator.CrossFade("Idle", 0.1f);
            }
            if (defendType == type)
                Opponent.TakeStun();

        }
        else
        {
            audio.PlayOneShot(hitSound, 1);
            currentState = State.TakeHit;
            MyAnimator.CrossFade("TakeHit" + type.ToString(), 0.1f);
            HP -= value;
            if (HP <= 0) StartCoroutine(Die());
            else
            {
                yield return new WaitForSeconds(2);
                currentState = State.Idle;
                MyAnimator.CrossFade("Idle", 0.1f);
            }

        }
    }
    public IEnumerator Attack(int attackType)
    {

        if (currentState == State.Idle || currentState == State.Block)
        {
            currentState = State.Attack;
            MyAnimator.CrossFade("Attack" + attackType.ToString(), 0.1f);
            yield return new WaitForSeconds(1f);
            if (currentState == State.Attack)
            {
                StartCoroutine(Opponent.TakeHit(attackType, MyWeapon.stats[attackType]));
                yield return new WaitForSeconds(1f);
                currentState = State.Idle;
                MyAnimator.CrossFade("Idle", 0.1f);
            }
        }
    }
    public IEnumerator Defend(int defendType)
    {
        if (currentState == State.Idle)
        {
            currentState = State.Block;
            MyAnimator.CrossFade("BlockIdle", 0.1f);
            yield return new WaitForSeconds(2);
            currentState = State.Idle;
            MyAnimator.CrossFade("Idle", 0.1f);
        }
    }
    public IEnumerator Die()
    {
        MyAnimator.CrossFade("Death", 0.1f);
        audio.PlayOneShot(deathSound, 1);
		yield return new WaitForSeconds (2);
        gameObject.SetActive(false);
    }
}
