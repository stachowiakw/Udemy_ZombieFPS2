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
            if (currentWeapon >= transform.childCount -1)
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
                currentWeapon = transform.childCount - 1;
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
            { weapon.SetActive(true); }
          else
            { weapon.SetActive(false); }
          i++;
        }

        GetComponentInChildren<WeaponZoom>().CheckZoomedWeaponEquip();
    }
}
