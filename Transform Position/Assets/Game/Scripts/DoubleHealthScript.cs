using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleHealthScript : MonoBehaviour
{
    public float DoubleHealth;
    public float SpeedTurn;

    private GameObject Player;
    private PlayerMovement PlayerScript;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        PlayerScript = Player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,SpeedTurn,0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player"&& PlayerScript.Health < 100)
        {
            PlayerScript.Health += DoubleHealth;
            Destroy(gameObject);
        }
    }
}
