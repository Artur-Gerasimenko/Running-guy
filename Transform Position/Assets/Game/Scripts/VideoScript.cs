/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class VideoScript : MonoBehaviour, IUnityAdsInitializationListener
{

    [SerializeField] string _androidGameId = "4815593";
    [SerializeField] string _iOSGameId = "4815592";
    [SerializeField] bool _testMode = true;
    private string _gameId;
    void Awake()
    {
        InitializeAds();
    }

    public void InitializeAds()
    {
        _gameId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? _iOSGameId
            : _androidGameId;
        Advertisement.Initialize(_gameId, _testMode,this);
    }
    public void OnInitializationComplete()
    {

    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}*/
