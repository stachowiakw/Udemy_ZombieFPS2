using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    float zoomOffFov = 60f;
    float zoomOnFov = 30f;
    bool zoomOn = false;
    bool zoomEquiped = false;
    [SerializeField] GameObject[] zoomEquipedWeapons; 

    void Update()
    {
        if (zoomEquiped == false)
        {
            MakeZoomOff();
        }
        
        if (Input.GetMouseButtonDown(1))
        {
            if (zoomOn == true)
            {
                MakeZoomOff();
            }
            else
            {
                MakeZoomOn();
            }
        }
    }

    private void MakeZoomOff()
    {
        zoomOn = false;
        GetComponent<Camera>().fieldOfView = zoomOffFov;
    }

    private void MakeZoomOn()
    {
        if (CheckZoomedWeaponEquip() == false)
        { return; }
        else
        {
            zoomOn = true;
            GetComponent<Camera>().fieldOfView = zoomOnFov;
        }
    }

    private bool CheckZoomedWeaponEquip()
    {
        foreach (GameObject weapon in zoomEquipedWeapons)
        {
            zoomEquiped = weapon.activeInHierarchy;
            if (zoomEquiped == true)
            { return true; }
        }
        return false;
    }
}
