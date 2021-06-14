using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp_Ammo : MonoBehaviour
{
    public AmmoType ammoType;
    [SerializeField] int ammoAmountAdd;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.GetComponentInChildren<PlayerHealth>() == true)
        { 
            Debug.Log("Trigger z graczem");
            GiveAmmo(other);
            Destroy(gameObject);
        }
        else
        { 
            Debug.Log("Trigger"); 
        }
    }

    private void GiveAmmo(Collider targetPlayer)
    {
        targetPlayer.GetComponent<Ammo>().AddAmmo(ammoType, ammoAmountAdd);
    }

}


