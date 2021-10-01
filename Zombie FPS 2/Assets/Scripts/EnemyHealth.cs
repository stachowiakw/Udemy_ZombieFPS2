using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    

    public void doDamage(float damageGiven)
    {
        hitPoints = hitPoints - damageGiven;
        GetComponent<EnemyAI>().OnDamageTaken();
        if (hitPoints<=0 && GetComponent<EnemyAI>().getAliveStatus())
        {
            GetComponent<EnemyAI>().setAliveStatus(false);
            GetComponent<Animator>().SetTrigger("death");
            GetComponent<CapsuleCollider>().enabled = false;
            //Destroy(gameObject);
        }   
    }
}
