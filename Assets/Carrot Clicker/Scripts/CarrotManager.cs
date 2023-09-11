using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;

public class CarrotManager : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private TextMeshProUGUI carrotsText;


    [Header(" Data ")]
    [SerializeField] private double totalCarrotsCount;
    [SerializeField] private int frenzyModeMultiplier;
    private int carrotIncrement;

    private void Awake()
    {
        LoadData();

        carrotIncrement = 1;

        InputManager.onCarrotClicked += CarrotClickedCallback;

        Narwhal.onFrenzyModeStarted += FrenzyModeStartedCallback;
        Narwhal.onFrenzyModeStopped += FrenzyModeStoppedCallback;
    }

    private void OnDestroy()
    {
        InputManager.onCarrotClicked -= CarrotClickedCallback;

        Narwhal.onFrenzyModeStarted -= FrenzyModeStartedCallback;
        Narwhal.onFrenzyModeStopped -= FrenzyModeStoppedCallback;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CarrotClickedCallback()
    {
        totalCarrotsCount += carrotIncrement;

        UpdateCarrotsText();

        SaveData();

    }

    private void UpdateCarrotsText()
    {
        carrotsText.text = totalCarrotsCount + " Narwhals!";
    }

    private void FrenzyModeStartedCallback()
    {
        carrotIncrement = frenzyModeMultiplier;
    }

    private void FrenzyModeStoppedCallback()
    {
        carrotIncrement = 1;
    }

    private void SaveData()
    {
        PlayerPrefs.SetString("Narwhals", totalCarrotsCount.ToString());
    }

    private void LoadData()
    {
        double.TryParse(PlayerPrefs.GetString("Narwhals"), out totalCarrotsCount);

        UpdateCarrotsText();
    }

    public int GetCurrentMultiplier()
    {
        return carrotIncrement;
    }
}
