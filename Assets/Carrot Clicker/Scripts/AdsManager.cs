using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AdsManager : MonoBehaviour
{
    [Header(" Settings ")]
    [SerializeField] private string appKey;

    private void Awake()
    {
        IronSourceEvents.onSdkInitializationCompletedEvent += SdkInitializationCompletedEvent;
    }

    private void OnDestroy()
    {
        IronSourceEvents.onSdkInitializationCompletedEvent -= SdkInitializationCompletedEvent;
    }

    // Start is called before the first frame update
    void Start()
    {

        IronSource.Agent.setMetaData("is_test_suite", "enable");


        IronSource.Agent.init(
            appKey, 
            IronSourceAdUnits.REWARDED_VIDEO, 
            IronSourceAdUnits.INTERSTITIAL, 
            IronSourceAdUnits.OFFERWALL, 
            IronSourceAdUnits.BANNER
            );

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SdkInitializationCompletedEvent() 
    {
        IronSource.Agent.launchTestSuite();
    }
}
