using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class PlayerMovement : MonoBehaviour
{
    public float Speed;
    public float SideSpeed = 0.5f;
    public float Score;
    public Text ScoreText;
    public float Health;
    public float DistanseTurn;
    public GameObject GameOverPanel;
    public AudioClip GameOverSound;
    public float MinDistanceForContactWhithPoint;
    public AudioClip[] ClipsTakingDamage;
    public Material TakingDamageMaterial;
    public float TimeTakingDamage;

    [SerializeField]private Material DefaultMaterial;

    private AudioSource TransformAudio;
    private GameObject CoinText;
    private bool isMobile;
    private float DefaultPositionPlayerX;
    private bool IsFinished;
    private CoinsScript ScriptCoin;
    private Vector3 Pos;
    private GameObject Effect;
    private SkinnedMeshRenderer PlayerSkin;
    // Start is called before the first frame update
    void Start()
    {
        CoinText = GameObject.Find("TextCoins");
        DefaultMaterial = Resources.Load("DefaultPlayerMaterial", typeof(Material)) as Material;
        Debug.Log($"Material0 {DefaultMaterial == null}");
        isMobile = Application.isMobilePlatform;
        DefaultPositionPlayerX = transform.position.x;
        PlayerSkin = gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
        ReturnToDefaultSkin();
        ScriptCoin = CoinText.GetComponent<CoinsScript>();
        Pos = transform.position;
        Effect = GameObject.Find("Effect");
        Speed = PlayerPrefs.GetFloat("PlayerSpeed");
        SideSpeed = PlayerPrefs.GetFloat("PlayerLateralSpeed");
        TransformAudio = transform.GetComponent<AudioSource>();
        SavingParametesPlayer();
    }
        // Update is called once per frame
        void FixedUpdate()
        {
            Score = Score <= 0 ? 0 : Score;
            ScoreText.text = $"Score: {Score}";
            transform.position += new Vector3(0, 0, Speed * Time.fixedDeltaTime);
            if (Health <= 0)
            {
            GameOverPanel.SetActive(true);
            GameOverPanel.GetComponent<AudioSource>().PlayOneShot(GameOverSound);
            Speed = 0;
            gameObject.SetActive(false);
            }
            else if (Health >= 100) Health = 100f;
            if (!isMobile && !IsFinished)
            {
                IsWindows();
            }
            else if (isMobile && !IsFinished)
            {
                IsMobile();
            }
        }
    public void DoubleLive()
    {
        gameObject.SetActive(true);
        Health = 100;
        Speed = PlayerPrefs.GetFloat("PlayerSpeed");
    }
    private void TakingAudioVolume()
    {
        TransformAudio.volume = PlayerPrefs.GetFloat("AudioSliderEffect");
    }
    private void SavingParametesPlayer()
    {
        PlayerPrefs.SetFloat("PlayerSpeed", Speed);
        PlayerPrefs.SetFloat("PlayerLateralSpeed", SideSpeed);
    }
    public void TakingDamage(AudioClip[] Clips,float TimeTakingDamage) 
    {
        TakingAudioVolume();
        PlayerSkin.material = TakingDamageMaterial;
        int RandomClip = Random.Range(0, Clips.Length);
        TransformAudio.PlayOneShot(Clips[RandomClip]);
        Invoke("ReturnToDefaultSkin", TimeTakingDamage);
    }
    private void ReturnToDefaultSkin()
    {
        PlayerSkin.material = LibraryScript.SkinPlayer ?? DefaultMaterial;
    }
        private void IsMobile()
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, Camera.main.transform.position.y));
            float distance = GetDistance(mousePosition.x, transform.position.x);
            if (Input.touchCount > 0)
            {
                if (mousePosition.x > transform.position.x && distance > MinDistanceForContactWhithPoint)
                {
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(DefaultPositionPlayerX + DistanseTurn, transform.position.y, transform.position.z), SideSpeed * Time.fixedDeltaTime);
                }
                else if (mousePosition.x < transform.position.x && distance > MinDistanceForContactWhithPoint)
                {
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(DefaultPositionPlayerX - DistanseTurn, transform.position.y, transform.position.z), SideSpeed * Time.fixedDeltaTime);
                }
            }
        }
        private void IsWindows()
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y));
            float distance = GetDistance(mousePosition.x, transform.position.x);
            if (Input.GetMouseButton(0))
            {
                if (mousePosition.x > transform.position.x && distance > MinDistanceForContactWhithPoint)
                {
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(DefaultPositionPlayerX + DistanseTurn, transform.position.y, transform.position.z), SideSpeed * Time.fixedDeltaTime);

                } else if (mousePosition.x < transform.position.x && distance > MinDistanceForContactWhithPoint)
                {
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(DefaultPositionPlayerX - DistanseTurn, transform.position.y, transform.position.z), SideSpeed * Time.fixedDeltaTime);
                }
            }
        }
        private float GetDistance(float number1,float number2)
        {
             if (number1 > number2)
             {
                return number1 - number2;
             }
             else
             {
                return number2 - number1;
             }
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (other.name == "Finish")
            {
                Speed = 0;
                transform.GetComponent<Animator>().SetBool("Win", true);
                IsFinished = true;
                ScriptCoin.CountCoins += (int)(Score / 2);
                Score = 0;
                Effect.SetActive(false);
            }
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(Pos, DistanseTurn);
        }
}
