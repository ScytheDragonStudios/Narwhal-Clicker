using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Narwhal : MonoBehaviour
{

    [Header(" Elements ")]
    [SerializeField] private Transform narwhalRendererTransform;


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
        narwhalRendererTransform.localScale = Vector3.one * .8f;
        LeanTween.cancel(narwhalRendererTransform.gameObject);
        LeanTween.scale(narwhalRendererTransform.gameObject, Vector3.one * .7f, .15f).setLoopPingPong(1) ;
    }
}
