using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoClickManager : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private Transform rotator;
    [SerializeField] private GameObject starfishPrefab;

    [Header(" Settings ")]
    [SerializeField] private float rotatorSpeed;
    [SerializeField] private float rotatorRadius;
    private int currentStarfishIndex;

    [Header(" Data ")]
    [SerializeField] private int level;
    [SerializeField] private float narwhalsPerSecond;

    //[Header(" Settings ")]
    //[SerializeField] private float rotatorSpeed;


    private void Awake()
    {
        ShopManager.onUpgradePurchased += CheckIfCanUpgrade;
    }

    private void OnDestroy()
    {
        ShopManager.onUpgradePurchased -= CheckIfCanUpgrade;
    }


    // Start is called before the first frame update
    void Start()
    {
        LoadData();

        narwhalsPerSecond = level * .1f;

        InvokeRepeating("AddNarwhals", 1, 1);

        SpawnStarfish();

        //StartAnimatingStarfish();
    }

    // Update is called once per frame
    void Update()
    {
        rotator.Rotate(Vector3.forward * Time.deltaTime * rotatorSpeed);
    }

    private void CheckIfCanUpgrade(int upgradeIndex)
    {
        if (upgradeIndex == 0)
            Upgrade();
    }

    private void SpawnStarfish()
    {
        //Destroy all bunnies
        while(rotator.childCount > 0)
        {
            Transform starfish = rotator.GetChild(0);
            starfish.SetParent(null);
            Destroy(starfish.gameObject);
        }

        int starFishCount = Mathf.Min(level, 36);

        for (int i = 0; i < level; i++)
        {
            float angle = i * 10;

            Vector2 position = new Vector2();
            position.x = rotatorRadius * Mathf.Cos(angle * Mathf.Deg2Rad);
            position.y = rotatorRadius * Mathf.Sin(angle * Mathf.Deg2Rad);

            GameObject starFishInstance = Instantiate(starfishPrefab, position, Quaternion.identity, rotator);
            starFishInstance.transform.up = position.normalized;
        }
    }

    private void AddNarwhals()
    {
        CarrotManager.instance.AddNarwhals(narwhalsPerSecond);
        Debug.Log("Adding " + narwhalsPerSecond + " Narwhals");
    }

    public void Upgrade()
    {
        level++;

        narwhalsPerSecond = level * .1f;

        if (level <= 36)
            SpawnStarfish();
        //StartAnimatingStarfish();
    }

    /*private void StartAnimatingStarfish()
    {
        if (rotator.childCount <= 0)
            return;

        LeanTween.cancel(gameObject);

        for (int i = 0; i < rotator.childCount; i++)
        {
            LeanTween.cancel(rotator.GetChild(i).gameObject);
        }

        LeanTween.moveLocalY(rotator.GetChild(currentStarfishIndex).GetChild(0).gameObject, -0.1f, .125f)
            .setLoopPingPong(1)
            .setOnComplete(AnimateNextStarfish);
    }*/

   /* private void AnimateNextStarfish()
    {
        currentStarfishIndex++;

        if (currentStarfishIndex >= rotator.childCount)
            ResetStarfishAnimation();
        else
            StartAnimatingStarfish();
    }*/

    /*private void ResetStarfishAnimation()
    {
        currentStarfishIndex = 0;

        float delay = Mathf.Max(10 - rotator.childCount, 0);

        LeanTween.delayedCall(gameObject, delay, StartAnimatingStarfish);
    }*/

    private void LoadData()
    {
        level = ShopManager.instance.GetUpgradelevel(0);
    }
}
