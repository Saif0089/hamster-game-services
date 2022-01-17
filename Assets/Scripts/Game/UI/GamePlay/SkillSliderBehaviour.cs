using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class SkillSliderBehaviour : MonoBehaviour
{
    public UISliderBehaviour chargeSlider;

    public UISliderBehaviour regenSlider;

    private Ability abilityData;

    public UISliderSeparator sliderChargeSeparator;

    private bool isInitalized;
    public void Initializing(Ability ability)
    {
        SetupSlider(ability);
    }

    public void SetupSlider(Ability ability)
    {
        abilityData = ability;
        if(chargeSlider != null)
        {
            chargeSlider.SetupDisplay(ability.maxCharge);
            chargeSlider.SetCurrentValue(ability.currentCharge);
            ability.onCurrentChargeChanged += UpdateCharge;
        }
        if(regenSlider != null)
        {
            regenSlider.SetupDisplay(ability.skillData.totalCooldown);
            regenSlider.SetCurrentValue(ability.skillData.totalCooldown - ability.totalCD);
        }
        if(sliderChargeSeparator != null)
        {
            sliderChargeSeparator.SetSeperatorByNumber(ability.maxCharge);
        }

        isInitalized = true;
    }

    private void Update()
    {
        if (!isInitalized) return;

        UpdateRegenSlider(abilityData.skillData.totalCooldown - abilityData.totalCD);
    }

    private void UpdateRegenSlider(float value)
    {
        regenSlider.SetCurrentValue(value);
    }

    private void UpdateCharge(int value)
    {
        if(chargeSlider != null) chargeSlider.SetCurrentValue(value);
    }
}
