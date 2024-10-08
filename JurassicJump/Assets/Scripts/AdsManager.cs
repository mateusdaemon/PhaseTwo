using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] private string androidGameId = "5709211";
    [SerializeField] private bool testMode = true;

    private string interstitialAdId = "Interstitial_Android";
    private bool isLoaded = false;

    void Start()
    {
        InitializeAds();
    }

    public void InitializeAds()
    {
        Advertisement.Initialize(androidGameId, testMode, this);
    }

    public void OnInitializationComplete()
    {
        LoadInterstitialAd();
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }

    // Métodos para carregar e mostrar anúncios intersticiais
    public void LoadInterstitialAd()
    {
        Advertisement.Load(interstitialAdId, this);
    }

    public void ShowInterstitialAd()
    {
        if (isLoaded)
        {
            Advertisement.Show(interstitialAdId, this); // Passa 'this' como IUnityAdsShowListener
        }
        else
        {
            Debug.Log("Ad is not loaded yet.");
        }
    }

    // Implementações da interface IUnityAdsLoadListener
    public void OnUnityAdsAdLoaded(string adId)
    {
        isLoaded = true;
        Debug.Log($"Ad loaded: {adId}");
    }

    public void OnUnityAdsFailedToLoad(string adId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Failed to load ad: {adId} - {error.ToString()} - {message}");
        isLoaded = false;
    }

    // Implementações da interface IUnityAdsShowListener
    public void OnUnityAdsShowFailure(string adId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Failed to show ad: {adId} - {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowStart(string adId)
    {
        Debug.Log($"Ad shown: {adId}");
    }

    public void OnUnityAdsShowComplete(string adId, UnityAdsShowCompletionState showCompletionState)
    {
        Debug.Log($"Ad completed: {adId} with result: {showCompletionState}");
        LoadInterstitialAd(); // Recarrega o anúncio após a exibição
    }

    public void OnUnityAdsShowClick(string adId)
    {
        Debug.Log($"Ad clicked: {adId}");
    }
}
