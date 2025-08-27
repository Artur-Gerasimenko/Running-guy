using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class RewardedScript : MonoBehaviour
{
    [SerializeField] private int Index;
    private GameControllerScript GameController;
    private void OnEnable() => YandexGame.OpenVideoEvent += Reword;
    private void OnDisable() => YandexGame.CloseVideoEvent -= Reword;

    private void Reword(int number)
    {
        if (number == 1 && Index == 1)
        {
            FoundGameControllers();
            PlayerDoubleLive();
        }
    }
    private void FoundGameControllers()
    {
        GameController = GameObject.Find("GameController").GetComponent<GameControllerScript>();
        if (GameObject.Find("PanelDie")) GameObject.Find("PanelDie").SetActive(false);
    }
    private void PlayerDoubleLive()
    {
        GameController.Player.GetComponent<PlayerMovement>().DoubleLive();
    }
}
