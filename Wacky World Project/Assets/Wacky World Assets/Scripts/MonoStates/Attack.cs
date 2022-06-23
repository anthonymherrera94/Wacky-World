using MonoStates;
using PlayerManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Attack : AgentMState
{
    [SerializeField]
    private float attackRange = 5f;
    [SerializeField]
    private float attackCoolDown = 1f;
    [SerializeField]
    private int attackDamage = 1;

    [SerializeField] private MonoState onTargetOutOfRange;

    private float nextAttack;
    // Start is called before the first frame update
    void Start()
    {

        agent = GetComponent<NavMeshAgent>();
        Player = GameObject.FindGameObjectWithTag("Player");
        nextAttack = Time.time + attackCoolDown;
    }

    protected override void StateUpdate()
    {
        agent.SetDestination(Player.transform.position);

        if (Vector3.Distance(transform.position, Player.transform.position) <= attackRange)
        {
            if (nextAttack < Time.time)
            {
                PlayerManager.Instance.Health -= attackDamage;
                nextAttack = Time.time + attackCoolDown;
            }
        }
        else
            ProceedToNextStage(onTargetOutOfRange);
    }
}
