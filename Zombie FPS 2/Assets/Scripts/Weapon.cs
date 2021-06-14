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
    [SerializeField] AmmoType ammoType;
    [SerializeField] float timeBetweenShots = 0.5f;
    [SerializeField] float timeAfterChangingWeapons = 1f;
    bool canShoot = true;
    //bool weaponChangeFinished = true;

    private void OnEnable()
    {
        ammo = FindObjectOfType<Ammo>();
        ammo.SetAmmoCounterGUI(ammoType);
        canShoot = true;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && canShoot == true)
        {
            if (ammo.getAmmoBullets(ammoType) > 0)
            {
                StartCoroutine(Shoot());
            }
        }
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if (ammo.getAmmoBullets(ammoType) > 0)
        {
            ammo.ReduceCurrentAmmo(ammoType);
            ammo.SetAmmoCounterGUI(ammoType);
            PlayMuzzleFX();
            ProcessRaycasting();
        }
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
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
