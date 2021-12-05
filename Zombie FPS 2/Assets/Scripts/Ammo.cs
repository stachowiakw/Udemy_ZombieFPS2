using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Ammo : MonoBehaviour
{
    //[SerializeField] private int SelectedAmmo;
    //[SerializeField] private int ammoAmount;
    //[SerializeField] private int AmmoBulletsMaxLimit;
    //[SerializeField] private int AmmoShells;
    //[SerializeField] private int AmmoShellsMaxLimit;
    [SerializeField] private TextMeshProUGUI AmmoCounter;

    [SerializeField] AmmoSlot[] ammoSlots;
    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoAmount;
    }

    //public void setAmmoBullets(int ammoChange)
    //{
    //    if (ammoChange < 0 && ammoAmount <= 0)
    //        { ammoAmount = 0; }
    //    else if (ammoChange >=0 && ammoAmount >= AmmoBulletsMaxLimit)
    //        { ammoAmount = AmmoBulletsMaxLimit; }
    //    else
    //        { ammoAmount = ammoAmount + ammoChange; }
    //    AmmoCounter.text = ammoAmount.ToString();
    //}

    public void SetAmmoCounterGUI(AmmoType ammoType)
    {
        AmmoCounter.text = GetAmmoSlot(ammoType).ammoAmount.ToString();
    }

    public int getAmmoBullets(AmmoType ammoType)
    { 
        return GetAmmoSlot(ammoType).ammoAmount; 
    }    

    public void ReduceCurrentAmmo(AmmoType ammoType)
    {
        GetAmmoSlot(ammoType).ammoAmount--;
    }

    public void AddAmmo(AmmoType ammoType, int ammoAdded)
    {
        GetAmmoSlot(ammoType).ammoAmount = GetAmmoSlot(ammoType).ammoAmount+ammoAdded;
        if (ammoType == FindObjectOfType<WeaponSelector>().GetCurrentWeaponAmmoType())
        { SetAmmoCounterGUI(ammoType); }
    }

    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach (AmmoSlot slot in ammoSlots)
        {
            if (slot.ammoType == ammoType)
            {
                return slot;
            }
        }
        return null;
    }
}
