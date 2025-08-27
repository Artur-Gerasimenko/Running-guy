using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float Speed;
    public float DictanceAttack;
    public float DistanceAdvance;
    public float Damage;
    public float DefaultTimeDamage;
    public float DistanseBackPlayerDie;
    public float SpeedTurnToPlayer;
    public AudioClip[] ClipsAttack;

    private float TimeDamage;
    private GameObject Player;
    private PlayerMovement PlayerScript;
    private bool GoAttack;
    private Animator TransformAnimation;
    private AudioSource TransformAudio;
    // Start is called before the first frame update
    void Start()
    {
        TransformAudio = transform.GetComponent<AudioSource>();
        Player = GameObject.Find("Player");
        PlayerScript = Player.GetComponent<PlayerMovement>();
        TransformAnimation = transform.GetComponent<Animator>();
        TransformAudio.volume = PlayerPrefs.GetFloat("AudioSliderEffect");
    }
    private void Attack()
    {
        Vector3 distance = Player.transform.position - transform.position;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(distance), 0.5f);
        //transform.LookAt(Vector3.Lerp(transform.position, Player.transform.position,Speed));
       /* Quaternion.Lerp(
            new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, 0),
            new Quaternion(Player.transform.rotation.x, Player.transform.rotation.y, Player.transform.rotation.z,0),Speed);*/
        if (Vector3.Distance(transform.position, Player.transform.position) > DictanceAttack)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, Speed * Time.fixedDeltaTime);
            TransformAnimation.SetBool("Walk", true);
        }
        else
        {
            TransformAnimation.SetBool("Walk", false);
            TransformAnimation.SetBool("Attack", true);
            if (TimeDamage <= 0)
            {
                TransformAudio.PlayOneShot(ClipsAttack[Random.Range(0,ClipsAttack.Length - 1)]);
                PlayerScript.TakingDamage(PlayerScript.ClipsTakingDamage,PlayerScript.TimeTakingDamage);
                PlayerScript.Health -= Damage;
                TimeDamage = DefaultTimeDamage;
            }
            TimeDamage -= Time.deltaTime;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (Vector3.Distance(transform.position, Player.transform.position) < DistanceAdvance)
        {
            GoAttack = true;
        }
        else
        {
            TransformAnimation.SetBool("Walk", false);

        }
        if (transform.position.z < Player.transform.position.z - DistanseBackPlayerDie)
        {
            Destroy(gameObject);
        }
        if (GoAttack)
        {
            Attack();
        }
    }
}
