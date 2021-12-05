using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float PlayerHealthPoints = 100f;
    DeathHandler deathHandler;

    public void Start()
    {
        deathHandler = FindObjectOfType<DeathHandler>();
    }

    public void damagePlayerHealth(float DamageToThePlayer)
    {
        PlayerHealthPoints = PlayerHealthPoints - DamageToThePlayer;
        GameObject.FindObjectOfType<DamageVisuals>().ActivateRandomSplatter();
        checkIfDead();
    }

    private void checkIfDead()
    {
        if (PlayerHealthPoints<=0)
        {
            deathHandler.HandleDeath();
        }
    }

}
