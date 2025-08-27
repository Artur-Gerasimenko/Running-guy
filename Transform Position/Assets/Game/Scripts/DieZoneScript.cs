using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DieZoneScript : MonoBehaviour
{
    public float NewPlayerSpeed, NewSideSpeed, NewPlayerForceMoveX, Damage, StopDamage;
    public Canvas canvas;

    private GameObject Player;
    private PlayerMovement PlayerScript;
    private float timedamag = default;
    private float PlayerDefaultSpeed;
    private float PlayerDefaultSideSpeed;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        PlayerScript = Player.GetComponent<PlayerMovement>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    { 
        if (other.tag == "Player")
        {
            PlayerScript.Speed -= NewPlayerSpeed;
            PlayerScript.SideSpeed -= NewSideSpeed;

        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {

            if (timedamag <= 0)
            {
                //ScriptCanvas.TakingEffectVolume(ref PlayerScript.TransformAudio.volume);
                PlayerScript.TakingDamage(PlayerScript.ClipsTakingDamage, PlayerScript.TimeTakingDamage);

                PlayerScript.Health -= Damage;
                timedamag = StopDamage;
            }
            timedamag -= Time.deltaTime;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerScript.Speed += NewPlayerSpeed;
            PlayerScript.SideSpeed += NewSideSpeed;
            //Player.GetComponent<Animator>().GetComponent<Animation>().speed = DefaultAnimationSpeed;
        }
    }
}
