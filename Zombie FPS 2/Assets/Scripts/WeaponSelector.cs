using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelector : MonoBehaviour
{
    [SerializeField] GameObject[] Weapons;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        { selectWeapon(0); }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        { selectWeapon(1); }
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
