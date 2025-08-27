using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelScript : MonoBehaviour
{
    public AudioClip AudioEffect;

    public  AudioSource AudioTurntable;
    // Start is called before the first frame update
    void Start()
    {
        AudioTurntable = transform.GetComponent<AudioSource>();
    }
    private void TakingAudioVolume()
    {
        AudioTurntable.volume = PlayerPrefs.GetFloat("AudioSliderEffect");
    }
    // Update is called once per frame
    void Update()
    {
        TakingAudioVolume();
    }
}
