using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopWhileBattle : MonoBehaviour
{
    public static ShopWhileBattle instance;
    [SerializeField]
    private TextMeshProUGUI priceOfNOAds;
    [SerializeField]
    private TextMeshProUGUI OldPriceOfNOAds;
    [SerializeField]
    private Button buyNoAdsButton;

    [SerializeField]
    private GameObject limitedOfferPanel;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!GameParams.getAdsBought()) StartCoroutine(setStorePrice());
    }

    public void updateNoAdsSpecialUIAfterPurchase()
    {
        priceOfNOAds.text = "V";
        priceOfNOAds.color = Color.green;
        buyNoAdsButton.interactable = false;
    }

    public void showLimitedOffer()
    {
        limitedOfferPanel.SetActive(true);
    }
    public void hideLimitedOffer()
    {
        AudioManager.Instance.connectionVoice();
        limitedOfferPanel.SetActive(false);
    }




    IEnumerator setStorePrice()
    {
        //while (!IAPManagerOfGame.instance.IsInitialized())
        //{
        //    yield return null;
        //}
        yield return null;
        //priceOfNOAds.text = IAPManagerOfGame.instance.getProductPriceFromStore(IAPManagerOfGame.instance.NO_ADS_SPECIAL);
        //OldPriceOfNOAds.text = IAPManagerOfGame.instance.getProductPriceFromStore(IAPManagerOfGame.instance.NO_ADS);
    }
}
