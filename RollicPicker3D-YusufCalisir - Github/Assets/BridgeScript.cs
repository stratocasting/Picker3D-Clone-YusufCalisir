using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BridgeScript : MonoBehaviour
{
    public int requiredBalls;
    public int currentBalls;
    public bool enoughBalls;
    [SerializeField] TextMeshProUGUI text;
    public float bridgePos;
    [SerializeField] public GameObject upperBridge;
    [SerializeField] public GameObject Barriers;
    [SerializeField] public GameObject Barriers2;
    [SerializeField] GameObject superAwesome;
    [SerializeField] ParticleSystem partSys;
    List<string> superStrings= new List<string>();
    Vector3 barrierPos;
    Vector3 barrierPos2;
    string superAwesomeText;
    AudioSource yeyAudio;
    void Start()
    {
        yeyAudio = GetComponentInChildren<AudioSource>();
        barrierPos = Barriers.gameObject.transform.position;
        barrierPos2 = Barriers2.gameObject.transform.position;
        text.text = ($"{currentBalls}/{requiredBalls}");
        currentBalls = 0;
        string awesome = "AWESOME";
        string super = "SUPER";
        string amazing = "AMAZING";
        string incredible = "INCREDIBLE";
        superStrings.Add(awesome);
        superStrings.Add(super);
        superStrings.Add(amazing);
        superStrings.Add(incredible);
        superAwesomeText = superStrings[Random.Range(0, superStrings.Count - 1)];

    }

    // Update is called once per frame
    void Update()
    {
        bridgePos = transform.position.z;
        openDoors();
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            
            text.text = ($"{currentBalls}/{requiredBalls}");
            if (currentBalls >= requiredBalls)
            {

                
                StartCoroutine(BrigdeGoingUp());
                //bariyer
                LeanTween.rotateAroundLocal(Barriers, new Vector3(0, 40, 0), 60, .9f);
                if (Barriers.gameObject.transform.position != barrierPos)
                {
                    Barriers.gameObject.transform.position = barrierPos;
                }
                LeanTween.rotateAroundLocal(Barriers2, new Vector3(0, -40, 0), 60, .9f);
                if (Barriers2.gameObject.transform.position != barrierPos2)
                {
                    Barriers2.gameObject.transform.position = barrierPos2;
                }
                StartCoroutine(particlePlayDelay());
                superAwesome.GetComponentInChildren<TextMeshProUGUI>().text = superAwesomeText;
                superAwesome.SetActive(true);
                //LeanTween.scale(superAwesome, new Vector3(.3f, .3f, .3f), 2f).setLoopPingPong(1).setOnComplete(DestroyMe);
                LeanTween.scale(superAwesome, new Vector3(6f, 6f, 6f), .7f).setOnComplete(LeanGoSmall);
        
            }
        }
        

    }
    void LeanGoSmall()
    {
        LeanTween.scale(superAwesome, new Vector3(.3f, .3f, .3f), .5f).setOnComplete(DestroyMe);
    }
    void DestroyMe()
    {
        superAwesome.SetActive(false);
    }
    IEnumerator BrigdeGoingUp()
    {
        yield return new WaitForSeconds(1.5f);
        LeanTween.moveLocalY(upperBridge, 3.20f, .7f);
        enoughBalls = true;
        partSys.Play();
        if(!yeyAudio.isPlaying)
        {
            yeyAudio.volume = 0.400f;
            yeyAudio.PlayOneShot(yeyAudio.clip);
        }
        
    }
    IEnumerator particlePlayDelay()
    {
        yield return new WaitForSeconds(.3f);
        partSys.Play();
    }
    void openDoors()
    {
        if (enoughBalls)
        {
            
            
        }
    }

}
