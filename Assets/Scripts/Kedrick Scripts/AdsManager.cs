using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using System;


public class AdsManager : MonoBehaviour, IUnityAdsListener
{
     
#if UNITY_IOS
   private string gameId = "4209906";
#elif UNITY_ANDROID
    private string gameId = "4209907";
#endif


    

    void Start()
    {
        // Initialize the Ads service:
        Advertisement.Initialize(gameId);
        Advertisement.AddListener(this);
        ShowBanner();
    }
   
    public void PlayRewardedAd()
    {
       
        // Check if UnityAds ready before calling Show method:
        if (Advertisement.IsReady("rewardedVideo"))
        {
            Advertisement.Show("rewardedVideo");
            // Replace mySurfacingId with the ID of the placements you wish to display as shown in your Unity Dashboard.
        }
        else
        {
            Debug.Log("Rewarded ad is not ready!");
        }
    }

        public void PlayAd()
        {
            // Check if UnityAds ready before calling Show method:
            if (Advertisement.IsReady("Video"))
            {
                Advertisement.Show("Video");
                // Replace mySurfacingId with the ID of the placements you wish to display as shown in your Unity Dashboard.
            }

        KedrickGameFlow.AdShowing = true;

        }
    
    

    public void ShowBanner() {
        if (Advertisement.IsReady("banner"))
        {
            Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
            Advertisement.Banner.Show("banner");
        }
        else
        {
            StartCoroutine(RepeatShowBanner());
        }
    }

    IEnumerator RepeatShowBanner()
    {
        yield return new WaitForSeconds(1);
        ShowBanner();
    }

    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log("Ads are ready!");
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.Log("ERROR: "+ message);
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("Video Started");
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (placementId == "rewardedVideo" && showResult == ShowResult.Finished) {
            KedrickMovementScript.OnRewardedAdSuccess();
        }
    }
}
