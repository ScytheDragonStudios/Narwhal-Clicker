using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShopManager : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private RectTransform shopPanel;

    [Header(" Settings ")]
    private Vector2 openedPosition;
    private Vector2 closedPosition;

    // Start is called before the first frame update
    void Start()
    {
        openedPosition = Vector2.zero;
        closedPosition = new Vector2(shopPanel.rect.width, 0);

        shopPanel.anchoredPosition = closedPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Open()
    {
        LeanTween.cancel(shopPanel);
        LeanTween.move(shopPanel, openedPosition, .3f).setEase(LeanTweenType.easeInOutSine);
    }

    public void Close()
    {
        LeanTween.cancel(shopPanel);
        LeanTween.move(shopPanel, closedPosition, .3f).setEase(LeanTweenType.easeInOutSine);
    }
}
