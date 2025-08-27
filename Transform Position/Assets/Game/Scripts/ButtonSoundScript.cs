using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSoundScript : MonoBehaviour
{
    public Sprite OnButton, OffButton;
    public Slider slider;

    private Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = transform.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value == 0) image.sprite = OffButton;
        else image.sprite = OnButton;
    }
    public void ONSound()
    {
        float on = PlayerPrefs.GetFloat("OnSound");
        if (on <= 0)
        {
            PlayerPrefs.SetFloat("OnSound", 1f);
            slider.value = 0f;
            image.sprite = OffButton;
            return;
        }
        if (on >= 1)
        {
            
            PlayerPrefs.SetFloat("OnSound", 0f);
            slider.value = 1f;
            image.sprite = OnButton;
            return;
        }
    }
    public void ONSoundEffect()
    {
        float on = PlayerPrefs.GetFloat("OnSoundEffect");
        if(on <= 0)
        {
            PlayerPrefs.SetFloat("OnSoundEffect", 1f);
            slider.value = 0f;
            image.sprite = OffButton;

        }else if(on >= 1)
        {
            PlayerPrefs.SetFloat("OnSoundEffect", 0f);
            slider.value = 1f;
            image.sprite = OnButton;
        }
    }
}
