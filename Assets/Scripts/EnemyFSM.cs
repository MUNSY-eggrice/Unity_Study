using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFSM : MonoBehaviour
{
    enum EnemyState
    {
        Idle,
        Move,
        Attack,
        Return,
        Damaged,
        Die
    }

    EnemyState m_State;

    public float findDistance = 8f;

    public float attackDistance = 2f;

    public float moveSpeed = 5f;

    public int attackPower = 3;


    float currentTime = 0;
    float attackDelay = 2f;
    CharacterController cc;

    Transform player;
    void Start()
    {
        m_State = EnemyState.Idle;

        player = GameObject.Find("Player").transform;
        cc = GetComponent<CharacterController>();
    }
    void Idle()
    {
        if (Vector3.Distance(transform.position, player.position) < findDistance)
        {
            m_State = EnemyState.Move;
            print("Change state: Idle -> Move");
        }
    }
    void Move()
    {
        if (Vector3.Distance(transform.position, player.position) > attackDistance)
        {
            Vector3 dir = (player.position - transform.position).normalized;
            cc.Move(dir * moveSpeed * Time.deltaTime);
        }
        else
        {
            m_State = EnemyState.Attack;
            currentTime = attackDelay;
            print("Change state: Move -> Attack");
        }
    }
    void Attack()
    {
        if (Vector3.Distance(transform.position, player.position) < attackDistance)
        {
            currentTime += Time.deltaTime;
            if(currentTime > attackDelay)
            {
                player.GetComponent<PlayerMove>();
                print("atk");
                currentTime = 0;
            }
        }
        else
        {
            m_State = EnemyState.Move;
            print("att->Move");
            currentTime = 0;
        }
    }
    void Return()
    {

    }
    void Damaged()
    {

    }
    void Die()
    {

    }
    void Update()
    {
        switch (m_State)
        {
            case EnemyState.Idle:
                Idle();
                break;
            case EnemyState.Move:
                Move();
                break;
            case EnemyState.Attack:
                Attack();
                break;
            case EnemyState.Return:
                Return();
                break;
            case EnemyState.Damaged:
                Damaged();
                break;
            case EnemyState.Die:
                Die();
                break;
        }
    }
}

