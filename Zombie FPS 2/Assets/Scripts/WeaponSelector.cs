using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using UnityEngine;

public class WeaponSelector : MonoBehaviour
{
    [SerializeField] GameObject[] Weapons;
    [SerializeField] int currentWeapon = 0;
    private int previousWeapon;
    [SerializeField] private AmmoType currentWeaponAmmoType;

    private void Start()
    {
        selectWeapon(currentWeapon);
    }

    private void Update()
    {
        previousWeapon = currentWeapon;
        ProcessKeyInput();
        ProcessScrollWheel();

        if (previousWeapon != currentWeapon)
        {
            selectWeapon(currentWeapon);
        }
    }

    private void ProcessKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        { currentWeapon = 0; }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        { currentWeapon = 1; }
    }

    private void ProcessScrollWheel()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (currentWeapon >= transform.childCount -2)
                // TODO: number -2 represents current weapon as well as FLESHLIGHT. Need to make function that will allow to count proper number manually
            {
                currentWeapon = 0;
            }
            else
            { 
                currentWeapon++; 
            }
        }
        else if ((Input.GetAxis("Mouse ScrollWheel") < 0))
        {
            if (currentWeapon <= 0)
            {
                currentWeapon = transform.childCount - 2;
                // TODO: number -2 represents current weapon as well as FLESHLIGHT. Need to make function that will allow to count proper number manually
            }
            else
            {
                currentWeapon--;
            }
        }
    }

    private void selectWeapon(int WeaponNumber)
    {
        int i = 0;
        foreach (GameObject weapon in Weapons)
        { if (WeaponNumber == i)
            { 
                weapon.SetActive(true);
                currentWeaponAmmoType = weapon.GetComponent<Weapon>().ammoType;
            }
          else
            { weapon.SetActive(false); }
          i++;
        }

        GetComponentInChildren<WeaponZoom>().CheckZoomedWeaponEquip();
    }

    public AmmoType GetCurrentWeaponAmmoType()
    { return currentWeaponAmmoType; }
    
}
