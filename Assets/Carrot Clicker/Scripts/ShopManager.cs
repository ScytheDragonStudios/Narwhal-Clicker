using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;

    [Header(" Elements ")]
    [SerializeField] private UpgradeButton upgradeButton;
    [SerializeField] private Transform upgradeButtonsParent;

    [Header(" Data ")]
    [SerializeField] private UpgradeSO[] upgrades;

    [Header(" Actions ")]
    public static Action<int> onUpgradePurchased;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnButtons();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnButtons()
    {
        for (int i = 0; i < upgrades.Length; i++)
            SpawnButton(i);
    }

    private void SpawnButton(int index)
    {
        UpgradeButton upgradeButtonInstance = Instantiate(upgradeButton, upgradeButtonsParent);

        UpgradeSO upgrade = upgrades[index];

        int upgradeLevel = GetUpgradelevel(index);

        Sprite icon = upgrade.icon;
        string title = upgrade.title;
        string subtitle = string.Format("lvl{0} (+{1} Cps)", upgradeLevel, upgrade.cpsPerLevel);
        string price = upgrade.GetPrice(upgradeLevel).ToString("F0");

        upgradeButtonInstance.Configure(icon, title, subtitle, price);

        upgradeButtonInstance.GetButton().onClick.AddListener(() => UpgradeButtonClickedCallback(index));
    }

    private void UpgradeButtonClickedCallback(int upgradeIndex)
    {
        if (CarrotManager.instance.TryPurchase(GetUpgradePrice(upgradeIndex)))
            IncreseUpgradeLevel(upgradeIndex);
        else
            Debug.Log("You can't afford this upgrade");
    }
    



    private void IncreseUpgradeLevel(int upgradeIndex)
    {
        int currentUpgradeLevel = GetUpgradelevel(upgradeIndex);
        currentUpgradeLevel++;

        //Save upgrade levels
        SaveUpgradeLevel(upgradeIndex, currentUpgradeLevel);

        UpdateVisuals(upgradeIndex);

        onUpgradePurchased?.Invoke(upgradeIndex);
    }

    private void UpdateVisuals(int upgradeIndex)
    {
        UpgradeButton upgradeButton = upgradeButtonsParent.GetChild(upgradeIndex).GetComponent<UpgradeButton>();

        UpgradeSO upgrade = upgrades[upgradeIndex];

        int upgradeLevel = GetUpgradelevel(upgradeIndex);

        string subtitle = string.Format("lvl{0} (+{1} Cps)", upgradeLevel, upgrade.cpsPerLevel);
        string price = upgrade.GetPrice(upgradeLevel).ToString("F0");

        upgradeButton.UpdateVisuals(subtitle, price);
    }

    private double GetUpgradePrice(int upgradeIndex)
    {
        return upgrades[upgradeIndex].GetPrice(GetUpgradelevel(upgradeIndex));
    }

    public int GetUpgradelevel(int upgradeIndex)
    {
        return PlayerPrefs.GetInt("Upgrade" + upgradeIndex);
    }

    private void SaveUpgradeLevel(int upgradeIndex, int upgradeLevel)
    {
        PlayerPrefs.SetInt("Upgrade" + upgradeIndex, upgradeLevel);
    }

    public UpgradeSO[] GetUpgrades()
    {
        return upgrades;
    }
}
