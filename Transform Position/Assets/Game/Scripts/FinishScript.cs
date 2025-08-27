using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class FinishScript : MonoBehaviour
{
    public GameObject Menu;
    public float distnceToEffect;
    public GameObject[] Effects;
    public AudioClip ClipFireWorks, ClipFunnyShout;
    //public YandexSDK YandexAd;
    //[SerializeField] private InterstitialAds ReclamScript;
    

    private GameObject Player;
    private GameObject GameController;
    private AudioSource AudioGameController;
    private bool OneTimePlay;
    private AudioSource TransformAudio;
    //private InterstitialAds ReclamScript;
    // Start is called before the first frame update
    void Start()
    {

        
        //ReclamScript = GameObject.Find("ReclamObject").GetComponent<InterstitialAds>();
        Player = GameObject.Find("Player");
        GameController = GameObject.Find("GameController");
        AudioGameController = GameController.GetComponent<AudioSource>();
        TransformAudio = transform.GetComponent<AudioSource>();
        foreach (GameObject Object in Effects)
        {
            Object.SetActive(false);
        }
    }

    

    private void TakingAudioVolume()
    {
        AudioGameController.volume = PlayerPrefs.GetFloat("AudioSliderEffect");
        TransformAudio.volume = PlayerPrefs.GetFloat("AudioSliderEffect");
    }
    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position,Player.transform.position) < distnceToEffect)
        {
            TakingAudioVolume();
            PlayEffect();
            if (!OneTimePlay)
                PlayAudioClips(ClipsController: ClipFunnyShout, ClipTransform: ClipFireWorks);
            OneTimePlay = true;
        }
    }
    private void AddButtonActiveLevel()
    {
        int NowActiveLevel = SceneManager.GetActiveScene().buildIndex;
        if(NowActiveLevel >= PlayerPrefs.GetInt("Levels") && NowActiveLevel < SceneManager.sceneCountInBuildSettings - 1)
        {
            PlayerPrefs.SetInt("Levels", NowActiveLevel + 1);
        }
    }
    private void PlayEffect()
    {
        for (int i = 0; i < Effects.Length; i++)
        {
            Effects[i].SetActive(true);
        }
        
    }
    private void PlayAudioClips(AudioClip ClipTransform, params AudioClip[] ClipsController)
    {
        for(int i = 0;i < ClipsController.Length; i++)
        {
            AudioGameController.PlayOneShot(ClipsController[i]);
        }
        TransformAudio.PlayOneShot(ClipTransform);
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.name == "Player")
        {
            //if(!PlayerPrefs.HasKey("ads"))PercentAdvertising();
            Menu.SetActive(true);
            AddButtonActiveLevel();
        }
    }

    
}