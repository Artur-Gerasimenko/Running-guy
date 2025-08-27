using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SkillScript : MonoBehaviour
{
    public Text LevelText;
    public Text PrizeText;
    public float DoubleSkill;
    public float Prize;
    public float PercentExpensive;
    public float DefaultValueSkill;
    public float MaxLevel;
    public float TimeDestroyEffect;
    public Material IsBuy;
    public Material IsntBuy;
    public Material Bought;
    public TextMeshProUGUI CoinText;
    public GameObject ControllerSkills;
    public AudioClip[] SoundOnClick;
    public AudioClip DefaultClik;
    public GameObject Effect;

    public float Level = 1;
    private int Index;
    private bool isBuy = false;
    private ControllerSkillsScript ScriptControllerSkills;
    private CoinsScript ScriptCoins;
    private Material materialPrizeText;
    private AudioSource MainAudio;
    // Start is called before the first frame update
    void Start()
    {
        MainAudio = transform.GetComponent<AudioSource>();
        ScriptCoins = CoinText.GetComponent<CoinsScript>();
        ScriptControllerSkills = ControllerSkills.GetComponent<ControllerSkillsScript>();
        Index = ScriptControllerSkills.GetIndex(transform.name);
        GetPreservation();
    }

    // Update is called once per frame
    void Update()
    {
        LevelText.text = Level.ToString();
        if (Level < MaxLevel)
        {
            PrizeText.text = Prize.ToString();
            if (ScriptCoins.CountCoins >= Prize)
            {
                materialPrizeText = IsBuy;
                isBuy = true;
            }
            else
            {
                materialPrizeText = IsntBuy;
                isBuy = false;
            }
        }else if(Level >= MaxLevel)
        {
            materialPrizeText = Bought;
            PrizeText.text = "Max";
        }
        PrizeText.material = materialPrizeText;
        SetPreservation();
    }
    public void DestroyAllKeys()
    {
        PlayerPrefs.DeleteAll();
    }
    private float GivePercent(float Number)
    {
        return (int)(Number / 100 * PercentExpensive);
    }
    private void GetPreservation()
    {
        float DefaultValueSkillNumber = default;
        float LevelNumber = PlayerPrefs.GetFloat($"SkillLevel{Index}");
        float PrizeNumber = PlayerPrefs.GetFloat($"Prize{Index}");

        if (transform.name == "ButtonSpeed") DefaultValueSkillNumber = PlayerPrefs.GetFloat("PlayerSpeed");
        else if (transform.name == "ButtonLateralSpeed") DefaultValueSkillNumber = PlayerPrefs.GetFloat("PlayerLateralSpeed");

        Level = Level < LevelNumber ? LevelNumber : Level;
        DefaultValueSkill = DefaultValueSkill < DefaultValueSkillNumber ? DefaultValueSkillNumber : DefaultValueSkill;
        Prize = Prize < PrizeNumber ? PrizeNumber: Prize;
    }
    private void SetPreservation()
    {
        if (transform.name == "ButtonSpeed") PlayerPrefs.SetFloat($"PlayerSpeed", DefaultValueSkill);
        else if (transform.name == "ButtonLateralSpeed") PlayerPrefs.SetFloat("PlayerLateralSpeed", DefaultValueSkill);

        PlayerPrefs.SetFloat($"SkillLevel{Index}", Level);
        PlayerPrefs.SetFloat($"Prize{Index}", Prize);
    }
    public void PlayAudio()
    {   if (!isBuy || Level >= MaxLevel) MainAudio.PlayOneShot(DefaultClik);
        else if (isBuy) MainAudio.PlayOneShot(SoundOnClick[Random.Range(0, SoundOnClick.Length - 1)]);
    }
    private void PlayEffect()
    {
        Effect.SetActive(true);
        Invoke("DisappeareEffect",TimeDestroyEffect);
    }
    private void DisappeareEffect()
    {
        Effect.SetActive(false);
    }
    private void AudioVolume()
    {
        MainAudio.volume = PlayerPrefs.GetFloat("AudioSliderEffect");
    }
    public void OnClick()
    {
        if (isBuy && Level < MaxLevel)
        {
            PlayEffect();
            AudioVolume();
            ScriptCoins.CountCoins -= Prize;
            DefaultValueSkill += DoubleSkill;
            Prize += GivePercent(Number: Prize);
            Level++;
            SetPreservation();
        }
    }
}