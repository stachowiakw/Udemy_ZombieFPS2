using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryIndicator : MonoBehaviour
{
    [SerializeField] GameObject batteryFill;
    [SerializeField] float batteryFillPosition100p = 0f;
    [SerializeField] float batteryFillPosition0p = -340f;

   public void UpdateIndicator(float batteryLifeLevel)
    {
        batteryFill.transform.localPosition = new Vector3(batteryFillPosition0p + (batteryLifeLevel * Mathf.Abs(batteryFillPosition0p / 100)), batteryFill.transform.localPosition.y, batteryFill.transform.localPosition.z);
    }
}
