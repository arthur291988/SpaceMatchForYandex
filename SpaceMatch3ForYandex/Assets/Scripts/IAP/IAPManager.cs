using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class IAPManager : MonoBehaviour
{
    public static IAPManager instance;

    [DllImport("__Internal")]
    private static extern void BuyNoAds();

    [DllImport("__Internal")]
    private static extern void CheckNoAds();


    [DllImport("__Internal")]
    private static extern void BuyNoAdsSpecial();

    [DllImport("__Internal")]
    private static extern void CheckNoAdsSpecial();


    private void Awake()
    {
        instance = this; 
        //CheckNoAds();
        //CheckNoAdsSpecial();
    }

    public void buyNoAdsButtonSpecial() {
        BuyNoAdsSpecial();
    }
    public void buyNoAdsSpecialResult()
    {
        GameParams.setAdsBought(true);
        SaveAndLoad.instance.saveData();
        ShopWhileBattle.instance.updateNoAdsSpecialUIAfterPurchase();
    }

    public void buyNoAdsButtonFromMenu()
    {
        BuyNoAds();
    }

    public void buyNoAdsFromMenuResult()
    {
        GameParams.setAdsBought(true);
        SaveAndLoad.instance.saveData();
        ShopManager.instance.updateNoAdsUIAfterPUrchase();
    }
}
