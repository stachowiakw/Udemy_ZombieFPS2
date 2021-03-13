using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float damageGiven = 5f;
    [SerializeField] float turnSpeed = 5f;

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    [SerializeField] bool isProvoked = false;
    
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
    public void OnDamageTaken()
    {
        isProvoked = true;
    }

    private void EngageTarget()
    {
        FaceTarget();
        if (distanceToTarget > navMeshAgent.stoppingDistance)
        { ChaseTarget(); }

        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        { AttackTarget(); }
    }

    private void ChaseTarget()
    {
        navMeshAgent.SetDestination(target.position);
        GetComponent<Animator>().SetBool("attack", false);
        GetComponent<Animator>().SetTrigger("move");
    }

    private void AttackTarget()
    {
        //Debug.Log(name + " has seeked and is detroyin " + target.name);
        GetComponent<Animator>().SetBool("attack", true);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 1, 0, 0.75F);
        Gizmos.DrawSphere(transform.position, chaseRange);
    }
    
    private void HitPlayer()
    {
        if (target == null) return;
        Debug.Log(target.name + " got hit!");
        target.GetComponent<PlayerHealth>().damagePlayerHealth(damageGiven);
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }
}
