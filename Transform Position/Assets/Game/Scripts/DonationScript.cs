/*using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Purchasing;

public class DonationScript : MonoBehaviour
{
    
    public void OnPurchaseCompleted(Product product)
    {
        switch (product.definition.id)
        {
            case "ads":
                RemoveAds();
                break;
            case "Coins200":
                Add500Coins();
                break;
        }
    }

    private void RemoveAds()
    {
        PlayerPrefs.SetInt("ads", 0);

        //UIInfo.Instance.UpdateRemoveAdsButton();
    }

    private void Add500Coins()
    {
        GameObject.Find("MainText").GetComponent<CoinsScript>().CountCoins += 200f;
        //UIInfo.Instance.UpdateCoinsText();
    }
}*/
