using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.CrossPlatformInput;

public class WeaponZoom : MonoBehaviour
{
    float zoomOffFov = 60f;
    float zoomOnFov = 30f;
    bool zoomOn = false;
    bool zoomEquiped = false;
    [SerializeField] GameObject[] zoomEquipedWeapons;
    [SerializeField] RigidbodyFirstPersonController rigidbodyFirstPersonController;

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
        setMouseSensitivity(2f);
    }

    private void MakeZoomOn()
    {
        if (CheckZoomedWeaponEquip() == false)
        { return; }
        else
        {
            zoomOn = true;
            GetComponent<Camera>().fieldOfView = zoomOnFov;
            setMouseSensitivity(1f);
        }
    }

    public bool CheckZoomedWeaponEquip()
    {
        foreach (GameObject weapon in zoomEquipedWeapons)
        {
            zoomEquiped = weapon.activeInHierarchy;
            if (zoomEquiped == true)
            { return true; }
        }
        return false;
    }

    private void setMouseSensitivity(float sensitivity)
    {
        rigidbodyFirstPersonController.mouseLook.XSensitivity = sensitivity;
        rigidbodyFirstPersonController.mouseLook.YSensitivity = sensitivity;
    }
}
