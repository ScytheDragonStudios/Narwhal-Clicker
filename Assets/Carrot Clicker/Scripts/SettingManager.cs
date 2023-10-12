using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingManager : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private RectTransform settingsPanel;

    [Header(" Settings ")]
    private Vector2 openedPosition;
    private Vector2 closedPosition;

    // Start is called before the first frame update
    void Start()
    {
        openedPosition = Vector2.zero;
        closedPosition = new Vector2(settingsPanel.rect.width, 0);

        settingsPanel.anchoredPosition = closedPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Open()
    {
        LeanTween.cancel(settingsPanel);
        LeanTween.move(settingsPanel, openedPosition, .3f).setEase(LeanTweenType.easeInOutSine);
    }

    public void Close()
    {
        LeanTween.cancel(settingsPanel);
        LeanTween.move(settingsPanel, closedPosition, .3f).setEase(LeanTweenType.easeInOutSine);
    }
}
