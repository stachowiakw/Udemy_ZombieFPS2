using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float PlayerHealthPoints = 100f;

    public void damagePlayerHealth(float DamageToThePlayer)
    {
        PlayerHealthPoints = PlayerHealthPoints - DamageToThePlayer;
        checkIfDead();
    }

    private void checkIfDead()
    {
        if (PlayerHealthPoints<=0)
        {
            Debug.Log("GAME OVER");
        }
    }

}
