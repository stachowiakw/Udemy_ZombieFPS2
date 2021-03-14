using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] private float range = 100f;
    [SerializeField] private float currentWeaponDamage = 40f;
    [SerializeField] GameObject muzzleFX;
    [SerializeField] GameObject bulletFX;
    [SerializeField] Ammo ammo;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (ammo.getAmmoBullets() > 0)
            {
                Shoot();
            }
        }
    }

    private void Shoot()
    {
        ammo.setAmmoBullets(-1);
        PlayMuzzleFX();
        ProcessRaycasting();
    }

    private void PlayMuzzleFX()
    {
        muzzleFX.GetComponent<ParticleSystem>().Play();
    }

    private void ProcessRaycasting()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            Debug.Log("I hit: " + hit.transform.name);
            PlayBulletHit(hit.point);
            EnemyHealth targetHealth = hit.transform.GetComponent<EnemyHealth>();
            if (targetHealth)
            {
                targetHealth.doDamage(currentWeaponDamage);
            }
            
        }
        else
        {
            return;
        }
    }

    private void PlayBulletHit(Vector3 hitPosition)
    {
        GameObject BulletHit = Instantiate(bulletFX, hitPosition, Quaternion.Euler(0,0,0));
        Destroy(BulletHit, 1);
    }

}
