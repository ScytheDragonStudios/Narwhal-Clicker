using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("AddNarwhals", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void AddNarwhals()
    {
        UpgradeSO[] upgrades = ShopManager.instance.GetUpgrades();

        if (upgrades.Length <= 1)
            return;

        double totalNarwhals = 0;

        for (int i = 1; i < upgrades.Length; i++)
        {
            //Grab amount of Narwhals for Upgrades
            double upgradeNarwhals = upgrades[i].cpsPerLevel * ShopManager.instance.GetUpgradelevel(i);
            totalNarwhals += upgradeNarwhals;
        }

        CarrotManager.instance.AddNarwhals(totalNarwhals);
    }


    private void AddClicks()
    {

    }
}
