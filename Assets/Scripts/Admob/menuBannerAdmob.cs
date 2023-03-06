using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
public class menuBannerAdmob : MonoBehaviour
{
    private BannerView bannerView;

    void Start()
    {
        MobileAds.Initialize(initStatus => { });
        this.RequestBanner();
    }

    void RequestBanner()
    {
        // ca-app-pub-3940256099942544/6300978111  ** Örnek banner reklam kodu ANDROID
        // ca-app-pub-3940256099942544/2934735716  ** Örnek banner reklam kodu IOS

#if UNITY_ANDROID
        string reklamID = "ca-app-pub-3160122659260591/3607752108";
#elif UNITY_IPHONE
        string reklamID = "ca-app-pub-3160122659260591/1438552639";
#else
        string reklamID = "unexpected_platform";
#endif

        // Create a 320x50 banner at the top of the screen.
        this.bannerView = new BannerView(reklamID, AdSize.Banner, AdPosition.Bottom);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the banner with the request.
        this.bannerView.LoadAd(request);



    }






   
}
