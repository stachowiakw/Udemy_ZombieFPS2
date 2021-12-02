using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp_Battery : MonoBehaviour
{
    [SerializeField] int batteryPercentageAdd;

    private void OnTriggerEnter(Collider other)
    {

        if (other.GetComponentInChildren<PlayerHealth>() == true)
        {
            Debug.Log("Trigger z graczem");
            GiveBattery(other);
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Trigger");
        }
    }

    private void GiveBattery(Collider targetPlayer)
    {
        targetPlayer.GetComponentInChildren<FlashlightSystem>().AddPower();
    }

}


