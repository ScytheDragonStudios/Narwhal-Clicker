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
    [SerializeField] private int carrotIncrement;

    private void Awake()
    {
        LoadData();

        InputManager.onCarrotClicked += CarrotClickedCallback;
    }

    private void OnDestroy()
    {
        InputManager.onCarrotClicked -= CarrotClickedCallback;
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
        carrotsText.text = totalCarrotsCount + " Carrots!";
    }

    private void SaveData()
    {
        PlayerPrefs.SetString("Carrots", totalCarrotsCount.ToString());
    }

    private void LoadData()
    {
        double.TryParse(PlayerPrefs.GetString("Carrots"), out totalCarrotsCount);

        UpdateCarrotsText();
    }
}
