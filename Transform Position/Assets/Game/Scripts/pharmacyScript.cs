using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class pharmacyScript : MonoBehaviour
{
    public float TurnSpeed;
    public float MinValue;
    public float MaxValue;
    public GameObject EffectDestroy;
    public AudioClip ClipDestroy;

    private PlayerMovement PlayerScript;
    private float DoubleParametres;
    private GameObject Player;
    private GameObject GameController;
    private GameObject TextCoins;
    private CoinsScript ScriptCoins;
    private AudioSource GameControllerAudio;
    // Start is called before the first frame update
    void Start()
    {
        TextCoins = GameObject.Find("TextCoins");
        ScriptCoins = TextCoins.GetComponent<CoinsScript>();
        GameController = GameObject.Find("GameController");
        GameControllerAudio = GameController.GetComponent<AudioSource>();
        DoubleParametres = Random.Range(MinValue, MaxValue);
        Player = GameObject.Find("Player");
        PlayerScript = Player.GetComponent<PlayerMovement>();
    }


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, TurnSpeed, 0);

    }
    private void TakingAudioVolume()
    {
        GameControllerAudio.volume = PlayerPrefs.GetFloat("AudioSliderEffect");
    }
    private void ExportInformation()
    {
        TakingAudioVolume();
        GameControllerAudio.PlayOneShot(ClipDestroy);
        Instantiate(EffectDestroy, transform.position + new Vector3(0, 3, 0), Quaternion.identity);
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (transform.tag == "Score—omplement")
            {
                PlayerScript.Score += (int)DoubleParametres;
                ExportInformation();
            }
            if (transform.tag == "Coin—omplement")
            {
                ScriptCoins.CountCoins += (int)DoubleParametres;
                ExportInformation();
            }
            if (transform.tag == "PlayerSpeed—omplement")
            {
                PlayerScript.Speed += DoubleParametres;
                ExportInformation();
            }
            if (transform.tag == "DoubleHealth")
            {
                PlayerScript.Health += DoubleParametres;
                ExportInformation();
            }
        }
    }
}
