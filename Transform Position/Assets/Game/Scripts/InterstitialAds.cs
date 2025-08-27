/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Advertisements;

public class InterstitialAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{

    [SerializeField] private string androidAdID = "Interstitial_Android";
    [SerializeField] private string iOSAdID = "Interstitial_iOS";

    private string adID;

    void Awake()
    {
        adID = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? iOSAdID
            : androidAdID;
        LoadAd();
    }

    public void LoadAd()
    {
        
        Advertisement.Load(adID, this);
    }

    public void ShowAd()
    {
        
        Advertisement.Show(adID, this);
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
    }

    public void OnUnityAdsShowStart(string placementId)
    {
    }

    public void OnUnityAdsShowClick(string placementId)
    {
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        LoadAd();
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
    }
}*/