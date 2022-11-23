using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;
    public static PlayerMovement Instance { get { return instance; } }
    public float speed;
    [SerializeField] GameObject tutorialDragToStart;
    Rigidbody rb;
    [SerializeField] private float velocity = 10f;
    private float velocityDefault;
    BridgeScript BridgeScript;
    public bool canRun;
    public bool gameOver;
    public bool superAwesomeOn;
    public bool finish;
    [SerializeField] GameObject playerBuff;
    AudioSource PickupAudioSource;
    [SerializeField] AudioSource powerUpAudio;
    public bool killAllBalls;
    void Awake()
    {
        PickupAudioSource = GetComponent<AudioSource>();
        instance = this;
        BridgeScript = FindObjectOfType<BridgeScript>();
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        canRun = true;
        velocityDefault = velocity;
        velocity = 0;
    }
    void FixedUpdate()
    {
        if (canRun )
        {
            Vector3 MoveWhereISay = transform.position;

            if (Input.touchCount > 0  )
            {
                if (canRun)
                {
                    velocity = velocityDefault;
                }
                else
                {
                    velocity = 0;
                }

                tutorialDragToStart.SetActive(false);

                Touch finger = Input.GetTouch(0);
                if (finger.deltaPosition.x != 0)
                {

                    MoveWhereISay.x += finger.deltaPosition.x / 40;
                    MoveWhereISay.x = Mathf.Clamp(MoveWhereISay.x, -2.5f, 2.5f);
                }

            }
            var movZ = (velocity * Time.fixedDeltaTime) * 1;
            var novaPos = transform.position + new Vector3(0, 0, movZ);
            novaPos.x = MoveWhereISay.x;
            if (canRun && !finish)
            {
                rb.MovePosition(novaPos);
            }

            
        }
        if (BridgeScript.enoughBalls)
        {

            StartCoroutine(BridgeWaiter());
            Debug.Log(canRun);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            if (!PickupAudioSource.isPlaying && collision.gameObject.name != "iHeardYouBefore")
            {
                PickupAudioSource.PlayOneShot(PickupAudioSource.clip);
                collision.gameObject.name = "iHeardYouBefore";
            }
            
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bridge")
        {
            velocity = 0;
            BridgeScript = other.gameObject.GetComponent<BridgeScript>();
            BridgeScript.currentBalls = 0;
            BridgeScript.enoughBalls = false;
            canRun = false;
            other.gameObject.tag = "PassedBridge";
            playerBuff.SetActive(false);
            if (!BridgeScript.enoughBalls)
            {
                Debug.Log("yeteri kadar top tolanmamis");
                StartCoroutine(DeathWaiter());
            }

        }
        if (other.gameObject.tag == "Finish")
        {
            finish = true;
            velocity = 0;
            canRun=false;
        }
        if (other.gameObject.tag == "PowerUp")
        {
            other.gameObject.SetActive(false);
            playerBuff.SetActive(true);
            powerUpAudio.PlayOneShot(powerUpAudio.clip);
        }
    }
    
    IEnumerator BridgeWaiter()
    {
        velocity = velocityDefault;
        canRun = true;
        yield return new WaitForSeconds(1.2f);
    }
    IEnumerator DeathWaiter()
    {
        yield return new WaitForSeconds(4f);
        //just double check if player collected enough
        if (!BridgeScript.enoughBalls)
        {
            gameOver = true;
            killAllBalls = true;
        }
    }
}
