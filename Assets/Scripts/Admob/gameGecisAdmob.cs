using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class gameGecisAdmob : MonoBehaviour
{
    private InterstitialAd interstitial;

    [System.Obsolete]
    void Start()
    {
        this.RequestInterstitial(); 
    }

   [System.Obsolete]
    private void RequestInterstitial()
    {
#if UNITY_ANDROID
        string reklamID = "ca-app-pub-3160122659260591/1855686730";    //ca-app-pub-3940256099942544/1033173712
#elif UNITY_IPHONE
        string reklamID = "ca-app-pub-3160122659260591/2989908654";    // ca-app-pub-3940256099942544/4411468910
#else
        string reklamID = "unexpected_platform";
#endif

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(reklamID);

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);
        
    }

    [System.Obsolete]
    public void GameOver()
    {
        
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();          
        }

    }



}
