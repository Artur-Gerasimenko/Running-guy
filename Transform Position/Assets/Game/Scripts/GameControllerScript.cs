using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class GameControllerScript : MonoBehaviour
{
    public GameObject Player;
    public GameObject PanelGameOver;
    public GameObject[] Objects;
    public float DistanceDestroyObjects;
    public YandexGame Ad;

    private PlayerMovement ScriptPlayer;
    private PanelScript ScriptPanelGameOver;
    private bool PlayerDie;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Ad);
        ScriptPlayer = Player.GetComponent<PlayerMovement>();
        ScriptPanelGameOver = PanelGameOver.GetComponent<PanelScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ScriptPlayer.Health <= 0 && !PlayerDie)
        {
            GameOver();
            PlayerDie = true;
        }
        ActiveObjectsInScene();
    }
    private void ActiveObjectsInScene()
    {
        int IndexObject = 0;
        GameObject NearestObject = default;
        for (int i = 0; i < Objects.Length; i++) {
            if (Objects[i] != null)
            {
                NearestObject = Objects[i];
                break;
            }
        }
        for (int i = 0; i < Objects.Length; i++)
        {
            if(Objects[i] != null && Objects[i].transform.position.z - Player.transform.position.z < NearestObject.transform.position.z - Player.transform.position.z)
            {
                NearestObject = Objects[i];
                IndexObject = i;
            }
            
        }
        if(Player.transform.position.z - NearestObject.transform.position.z >= DistanceDestroyObjects)
        {
            Objects[IndexObject] = null;
            Destroy(NearestObject);
        }
    }
    private void GameOver()
    {
        PanelGameOver.SetActive(true);
        PanelGameOver.GetComponent<AudioSource>().PlayOneShot(ScriptPanelGameOver.AudioEffect);
        ScriptPlayer.Speed = 0;
    }
}
