using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    public void doDamage(float damageGiven)
    {
        hitPoints = hitPoints - damageGiven;
        if (hitPoints<=0)
        {
            Destroy(gameObject);
        }   
    }
}
