using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CostumeManager : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private RectTransform costumesPanel;

    [Header(" Settings ")]
    private Vector2 openedPosition;
    private Vector2 closedPosition;

    // Start is called before the first frame update
    void Start()
    {
        openedPosition = Vector2.zero;
        closedPosition = new Vector2(costumesPanel.rect.width, 0);

        costumesPanel.anchoredPosition = closedPosition;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Open()
    {
        LeanTween.cancel(costumesPanel);
        LeanTween.move(costumesPanel, openedPosition, .3f).setEase(LeanTweenType.easeInOutSine);
    }

    public void Close()
    {
        LeanTween.cancel(costumesPanel);
        LeanTween.move(costumesPanel, closedPosition, .3f).setEase(LeanTweenType.easeInOutSine);
    }
}
