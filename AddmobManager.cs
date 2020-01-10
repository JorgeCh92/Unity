using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AddmobManager : MonoBehaviour
{
    //Variables
    private BannerView bannerView;
    [SerializeField] private string appID = "ca-app-pub-4555545931670970~4135557451";
    [SerializeField] private string bannerID = "ca-app-pub-4555545931670970/1742980793";

    BannerView bannerAd;

    private void Awake()
    {
        MobileAds.Initialize(appID);
        ShowBannerAd();
    }

    public void OnClickDestroyBanner()
    {
        bannerAd.Destroy();
    }

    public void OnClickDestroyAd()
    {
        bannerAd.Destroy();
    }

    private void ShowBannerAd()
    {
        AdRequest request = new AdRequest.Builder().Build();

        bannerAd= new BannerView(bannerID, AdSize.SmartBanner, AdPosition.Top);
        bannerAd.LoadAd(request);
    }
}
