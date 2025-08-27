using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class ButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowVideoAd(int Index = 1)
    {
        GameObject.Find("YandexGame").GetComponent<YandexGame>()._RewardedShow(Index);
    }
}
