using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Ammo : MonoBehaviour
{
    [SerializeField] private int SelectedAmmo;
    [SerializeField] private int AmmoBullets;
    [SerializeField] private int AmmoBulletsMaxLimit;
    [SerializeField] private int AmmoShells;
    [SerializeField] private int AmmoShellsMaxLimit;
    [SerializeField] private TextMeshProUGUI AmmoCounter;

    public void Start()
    {
        AmmoBullets = 30;
    }

    public void setAmmoBullets(int ammoChange)
    {
        if (ammoChange < 0 && AmmoBullets <= 0)
            { AmmoBullets = 0; }
        else if (ammoChange >=0 && AmmoBullets >= AmmoBulletsMaxLimit)
            { AmmoBullets = AmmoBulletsMaxLimit; }
        else
            { AmmoBullets = AmmoBullets + ammoChange; }
        AmmoCounter.text = AmmoBullets.ToString();
    }

    public int getAmmoBullets()
    { 
        return AmmoBullets; 
    }    
}
