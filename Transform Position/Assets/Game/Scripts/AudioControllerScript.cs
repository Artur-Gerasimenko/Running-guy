using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioControllerScript : MonoBehaviour
{
    public GameObject SliderAudioMusic, SliderAudioEffect;

    private Slider SSliderAudioMusic, SSliderAudioEffect;
    // Start is called before the first frame update
    void Start()
    {
        SSliderAudioMusic = SliderAudioMusic.GetComponent<Slider>();
        SSliderAudioEffect = SliderAudioEffect.GetComponent<Slider>();
        if (!PlayerPrefs.HasKey("AudioSlider")) PlayerPrefs.SetFloat("AudioSlider", SSliderAudioMusic.maxValue);
        if (!PlayerPrefs.HasKey("AudioSliderEffect")) PlayerPrefs.SetFloat("AudioSliderEffect", SSliderAudioEffect.maxValue);
        SSliderAudioMusic.value = PlayerPrefs.GetFloat("AudioSlider");
        SSliderAudioEffect.value = PlayerPrefs.GetFloat("AudioSliderEffect");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
