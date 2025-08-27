using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSliderScript : MonoBehaviour
{
    public GameObject Player;
    public Material PerfectHealth, GoodHealth, BadHealth;

    private PlayerMovement PlayerScript;
    private Slider slider;
    // Start is called before the first frame update
    void Start()
    {

        PlayerScript = Player.transform.GetComponent<PlayerMovement>();
        slider = transform.GetComponent<Slider>();
        slider.maxValue = PlayerScript.Health;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = PlayerScript.Health;
        if (slider.value >= slider.maxValue - slider.maxValue / 4)
        {
            slider.fillRect.GetComponent<Image>().material = PerfectHealth;
        }
        else if (slider.value < slider.maxValue - slider.maxValue / 4 && slider.value >= slider.maxValue - slider.maxValue / 4 * 3)
        {
            slider.fillRect.GetComponent<Image>().material = GoodHealth;
        }
        else if (slider.value < slider.maxValue - slider.maxValue / 4 * 3)
        {
            slider.fillRect.GetComponent<Image>().material = BadHealth;
        }
    }
}

