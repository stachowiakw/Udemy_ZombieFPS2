﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;
    
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (isProvoked)
        { EngageTarget(); }
        else if (distanceToTarget <= chaseRange)
        { isProvoked = true; }
        //    else
        //    { navMeshAgent.SetDestination(transform.position); }
        //
    }

    private void EngageTarget()
    {
        if (distanceToTarget > navMeshAgent.stoppingDistance)
        { ChaseTarget(); }

        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        { AttackTarget(); }
    }

    private void ChaseTarget()
    {
        navMeshAgent.SetDestination(target.position);
    }

    private void AttackTarget()
    {
        Debug.Log(name + " has seeked and is detroyin " + target.name);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 1, 0, 0.75F);
        Gizmos.DrawSphere(transform.position, chaseRange);
    }
}
