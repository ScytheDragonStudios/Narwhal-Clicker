using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoClickManager : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private Transform rotator;

    [Header(" Settings ")]
    [SerializeField] private float rotatorSpeed;

    [Header(" Data ")]
    [SerializeField] private int level;
    [SerializeField] private float narwhalsPerSecond;

    //[Header(" Settings ")]
    //[SerializeField] private float rotatorSpeed;


    private void Awake()
    {
        LoadData();
    }


    // Start is called before the first frame update
    void Start()
    {
        narwhalsPerSecond = level * .1f;

        InvokeRepeating("AddNarwhals", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        rotator.Rotate(Vector3.forward * Time.deltaTime * rotatorSpeed);
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

        SaveData();
    }

    private void LoadData()
    {
        level = PlayerPrefs.GetInt("AutoClickLevel");
    }

    private void SaveData()
    {
        PlayerPrefs.SetInt("AutoClickLevel", level);
    }
}
