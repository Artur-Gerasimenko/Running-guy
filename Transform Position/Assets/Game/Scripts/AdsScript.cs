using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdsScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ShowAd();
    }

    private void ShowAd()
    {
        Application.ExternalCall("ShowAd");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
