using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicCanvasScript : MonoBehaviour
{
    public AudioClip[] Clips;

    private float TimeClip;
    private AudioSource Music;
    // Start is called before the first frame update
    void Start()
    {
        Music = transform.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        MusicVoulme();
        TimeTracks();
    }
    private void MusicVoulme()
    {
        Music.volume = PlayerPrefs.GetFloat("AudioSlider");
    }
    private void TimeTracks()
    {
        if (TimeClip <= 0)
        {
            int NumberTrack = Random.Range(0, Clips.Length);
            Music.PlayOneShot(Clips[NumberTrack]);
            TimeClip = Clips[NumberTrack].length;
        }
        TimeClip -= Time.deltaTime;
    }
}