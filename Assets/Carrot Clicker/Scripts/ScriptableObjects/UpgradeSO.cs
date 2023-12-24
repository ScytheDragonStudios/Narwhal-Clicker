using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UpgradeType
{
    Autoclick,
    Tap,
}

[CreateAssetMenu(fileName ="Upgrade Data", menuName = "Scriptable Objects/Upgrade Data", order = 0)]
public class UpgradeSO : ScriptableObject
{
    [Header(" General ")]
    public Sprite icon;
    public string title;

    [Header(" Settings ")]
    public double cpsPerLevel;
    public double basePrice;
    public float coefficient;

    [Header(" Upgrade Type ")]
    public UpgradeType upgradeType;

    public double GetPrice(int level)
    {
        return basePrice * Mathf.Pow(coefficient, level);
    }
}
