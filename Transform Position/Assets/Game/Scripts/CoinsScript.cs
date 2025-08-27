using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

    public class CoinsScript : MonoBehaviour
    {
        public float CountCoins;

        private TextMeshProUGUI TransformText;
        // Start is called before the first frame update
        void Start()
        {
            TransformText = GetComponent<TextMeshProUGUI>();
            CountCoins = PlayerPrefs.GetFloat("Coins");

        }

        // Update is called once per frame
        void Update()
        {
            TransformText.text = CountCoins.ToString();
            PlayerPrefs.SetFloat("Coins", CountCoins);
        }
        /*public void IsPlayerFinished(float ScoreText)
        {
            TransformText.text = (float.Parse(TransformText.text) + (ScoreText / 2)).ToString();
            Debug.Log(TransformText.text);
        }*/
    }

