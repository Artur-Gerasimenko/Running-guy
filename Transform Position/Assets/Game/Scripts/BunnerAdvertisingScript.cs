/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class BunnerAdvertisingScript : MonoBehaviour
{
    [SerializeField] private BannerPosition Position;
    [SerializeField] private string AndroidID = "Banner_Android";
    [SerializeField] private string IOSID = "Banner_iOS";
    private string id;
    // Start is called before the first frame update
    
    private void GetPlatform()
    {
        id = Application.platform == RuntimePlatform.Android ? AndroidID : IOSID;
    }
    private void Start()
    {
        Advertisement.Banner.SetPosition(Position);
        StartCoroutine(LoadAdBanner());
    }
    private IEnumerator LoadAdBanner()
    {
        yield return new WaitForSeconds(1f);
        LoadBanner();
    }

    public void LoadBanner()
    {
        BannerLoadOptions options = new BannerLoadOptions
        {
            loadCallback = OnBannerLoaded,
            errorCallback = OnBannerError
        };

        Advertisement.Banner.Load(id, options);
    }

    private void OnBannerLoaded()
    {
       
        ShowBannerAd();
    }

    private void OnBannerError(string message)
    {
        Debug.Log($"Banner Error: {message}");
    }
    public void ShowBannerAd()
    {
        BannerOptions options = new BannerOptions
        {
            clickCallback = OnBannerClicked,
            hideCallback = OnBannerHidden,
            showCallback = OnBannerShown
        };
        Advertisement.Banner.Show(id, options);
    }
    private void OnBannerClicked() { }
    private void OnBannerShown() { }
    private void OnBannerHidden() { }

}*/
