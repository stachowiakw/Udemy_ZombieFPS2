using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FlashlightSystem : MonoBehaviour
{
    [SerializeField] float lightDecay = 0.1f;
    [SerializeField] float angleDecay = 1f;
    [SerializeField] float minimumAngle = 40f;
    [SerializeField] float flashlightPower;
    float flashlightPowerTempToNormalize;
    [SerializeField] private TextMeshProUGUI HUD_FlashlightBatteryIndicator;

    Light flashlightLight;
    [SerializeField] BatteryIndicator batteryIndicator;
    private float startingIntensity;
    private float startingAngle;

        private void Start()
    {
        flashlightLight = GetComponentInChildren<Light>(); 
        flashlightPowerTempToNormalize = flashlightLight.spotAngle;
        batteryIndicator = FindObjectOfType<BatteryIndicator>();
        startingIntensity = flashlightLight.intensity;
        startingAngle = flashlightLight.spotAngle;
    }

    private void Update()
    {
        DecreaseLightAngle();
        DecreaseLightIntencity();
        float flashlightPowerRaw = 100 * ((flashlightLight.spotAngle * flashlightLight.intensity) / flashlightPowerTempToNormalize);
        flashlightPower = Mathf.RoundToInt(flashlightPowerRaw);
        SetFlashlightBatteryCounterGUI(flashlightPower);
        batteryIndicator.UpdateIndicator(flashlightPowerRaw);
    }

    private void SetFlashlightBatteryCounterGUI(float flashlightPower)
    {
        HUD_FlashlightBatteryIndicator.text = flashlightPower.ToString() +"%";
    }

    private void DecreaseLightIntencity()
    {
        if (flashlightLight.spotAngle <= minimumAngle)
        { return; }
        else
        {
            flashlightLight.spotAngle -= angleDecay * Time.deltaTime;
        }
    }

    private void DecreaseLightAngle()
    {
        flashlightLight.intensity -= lightDecay * Time.deltaTime;
    }

    public void AddPower()
    {
        flashlightLight.intensity = startingIntensity;
        flashlightLight.spotAngle = startingAngle;
    }
}
