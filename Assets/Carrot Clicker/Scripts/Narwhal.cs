using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Narwhal : MonoBehaviour
{

    [Header(" Elements ")]
    [SerializeField] private Transform narwhalRendererTransform;
    [SerializeField] private Image fillImage;

    [Header(" Settings ")]
    [SerializeField] private float fillRate;
    private bool isFrenzyModeActive;

    [Header(" Actions ")]
    public static Action onFrenzyModeStarted;
    public static Action onFrenzyModeStopped;


    private void Awake()
    {
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
        //Animate Narwhal Renderer
        Animate();

        //Fill the image
        if (!isFrenzyModeActive)
            Fill();
    }

    private void Animate()
    {
        narwhalRendererTransform.localScale = Vector3.one * .8f;
        LeanTween.cancel(narwhalRendererTransform.gameObject);
        LeanTween.scale(narwhalRendererTransform.gameObject, Vector3.one * .7f, .15f).setLoopPingPong(1);
    }

    private void Fill()
    {
        fillImage.fillAmount += fillRate;

        if (fillImage.fillAmount >= 1)
            StartFrenzymode();
    }

    private void StartFrenzymode()
    {
        isFrenzyModeActive = true;

        LeanTween.value(1, 0, 5).setOnUpdate((value) => fillImage.fillAmount = value)
            .setOnComplete(StopFrenzyMode);

        onFrenzyModeStarted?.Invoke();
    }

    private void StopFrenzyMode()
    {
        isFrenzyModeActive = false;

        onFrenzyModeStopped?.Invoke();
    }
}
