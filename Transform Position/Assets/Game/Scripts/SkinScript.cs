using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using TMPro;
using YG;

public class SkinScript : MonoBehaviour
{
    public Material Skin;
    public string Prize;
    public Material ToBuyTrue, ToBuyFalse, BoughtText;
    public int FontSizeTextBought = 40;
    public bool Bought;
    public GameObject PanelStor;
    public bool isActiveSkin;
    public bool isAds;
    public AudioClip ClickIsBuy, ClickIsntBuy;
    public GameObject ImageAd;

    private YandexGame ScriptReclam; 
    private Text PrizeText;
    private GameObject Persone;
    private GameObject CoinsCount;
    private bool isBuy;
    private CoinsScript ScriptCoin;
    private StoreScript scriptStore;
    private int IndexButton;
    private AudioSource TransformAudio;
    // Start is called before the first frame update
    void Start()
    {
        if (isAds) ScriptReclam = GameObject.Find("YandexGame").GetComponent<YandexGame>();
        CoinsCount = GameObject.Find("MainText");
        TransformAudio = transform.GetComponent<AudioSource>();
        scriptStore = PanelStor.GetComponent<StoreScript>();
        IndexButton = scriptStore.GetIndex(transform.name);
        Persone = GameObject.Find("Player");
        PrizeText = transform.GetComponentInChildren<Text>();
        PrizeText.text = Prize.ToString();
        ScriptCoin = CoinsCount.GetComponent<CoinsScript>();
        if(PlayerPrefs.GetInt($"ActiveSkin{IndexButton}") == 1)
        {
            Debug.Log($"Yeah {IndexButton}");
            scriptStore.IsActiveSkin(IndexButton);
            isActiveSkin = true;
        }
        if (PlayerPrefs.GetInt($"Skin{IndexButton}") == 1)
        {
            Bought = true;
            IsBought();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!isAds)
        {
            if (ScriptCoin.CountCoins >= float.Parse(Prize) && !Bought)
            {
                PrizeText.material = ToBuyTrue;
                isBuy = true;
            }
            else if (ScriptCoin.CountCoins < float.Parse(Prize) && !Bought)
            {
                PrizeText.material = ToBuyFalse;
                isBuy = false;

            }
        }
        else if (Bought)
        {
            PrizeText.material = BoughtText;
        }
        PlayerPrefs.Save();
    }
    public void OnClick()
    {
        if (!isAds && !Bought)
        {
            if (isBuy && !Bought)
            {
                ScriptCoin.CountCoins -= float.Parse(Prize);
                Bought = true;
            }
            else if (!isBuy && !Bought)
            {
                TransformAudio.PlayOneShot(ClickIsntBuy);
            }
        }
        else if(isAds && !Bought)
        {
            ScriptReclam._RewardedShow(0);
            Bought = true;
        }
        if (Bought)
        {
            IsBought();
            TransformAudio.PlayOneShot(ClickIsBuy);
            PlayerPrefs.SetInt($"Skin{IndexButton}", 1);
            isActiveSkin = true;
            scriptStore.IsActiveSkin(IndexButton);
        }
    }
    private void IsBought()
    {
        transform.GetComponentInChildren<Text>().text = "Bought";
        if(isAds)ImageAd.SetActive(false);
        PrizeText.material = BoughtText;
        PrizeText.fontSize = FontSizeTextBought;
       
    }
}
