using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using EasyMobile;

public class AdManager : MonoBehaviour
{
    public TextMeshProUGUI intrestrailAD, rewardAD;
    
    void Awake()
    {
        if (!RuntimeManager.IsInitialized())
            RuntimeManager.Init();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Advertising.IsInterstitialAdReady())
        {
            intrestrailAD.text = "advert is ready";
            intrestrailAD.color = Color.green;
        }
        else
        {
            intrestrailAD.text = "advert is not ready";
            intrestrailAD.color = Color.red;
        }
        if (Advertising.IsRewardedAdReady())
        {
            rewardAD.text = "reward is ready";
            rewardAD.color = Color.green;
        }
        else
        {
            rewardAD.text = "reward is not ready";
            rewardAD.color = Color.red;
        }
    }
    public void ShowBannerAD()
    {
        Advertising.ShowBannerAd(BannerAdPosition.Bottom);
    }

    public void ShowInterstitialAD()
    {
        if(Advertising.IsInterstitialAdReady())
        {
            Advertising.ShowInterstitialAd();
        }
    }
    public void ShowRewardAD()
    {
        if (Advertising.IsRewardedAdReady())
        {
            Advertising.ShowRewardedAd();
        }
    }
}
