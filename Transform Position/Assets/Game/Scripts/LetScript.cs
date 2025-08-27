using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetScript : MonoBehaviour
{
    public float TurnSpeed;
    public float DamageHealth;
    public float DamageScore;

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
        transform.Rotate(0, TurnSpeed * Time.fixedDeltaTime, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            PlayerScript.Health -= DamageHealth;
            PlayerScript.Score -= DamageScore;
            PlayerScript.TakingDamage(PlayerScript.ClipsTakingDamage,PlayerScript.TimeTakingDamage);
        }
    }
}
