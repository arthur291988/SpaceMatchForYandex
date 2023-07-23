using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAPManager : MonoBehaviour
{
    public static IAPManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void buyNoAdsSpecial() {
        GameParams.setAdsBought(true);
        SaveAndLoad.instance.savePurchases();
        ShopWhileBattle.instance.updateNoAdsSpecialUIAfterPurchase();

        //AnalyticMain.instance.LogEvent("NoAdsSpecialBought");

    }
    public void buyNoAdsFromMenu()
    {
        GameParams.setAdsBought(true);
        SaveAndLoad.instance.savePurchases();
        ShopManager.instance.updateNoAdsUIAfterPUrchase();
        //AnalyticMain.instance.LogEvent("NoAdsBought");
    }
}
