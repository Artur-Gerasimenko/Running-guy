using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderAudioScript : MonoBehaviour
{
    private Slider TransformSlider;
    // Start is called before the first frame update
    void Start()
    {
        TransformSlider = transform.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.name == "SliderAudio") SliderSound();
        if (transform.name == "SliderAudioEffect") SliderAudioEffect();
    }
    private void SliderSound()
    {
        PlayerPrefs.SetFloat("AudioSlider", TransformSlider.value);
    }
    private void SliderAudioEffect()
    {
        PlayerPrefs.SetFloat("AudioSliderEffect", TransformSlider.value);
    }
}
