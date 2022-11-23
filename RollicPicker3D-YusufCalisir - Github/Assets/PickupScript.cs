using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    float startYPos;
    BridgeScript bridgeScript;
    float alpha = 1;
    byte alphaByte;
    

    void Start()
    {
        bridgeScript = FindObjectOfType<BridgeScript>();
        startYPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > startYPos + .1f)
        {
            transform.position = new Vector3(transform.position.x, startYPos +.1f, transform.position.z);
        }
        if (PlayerMovement.instance.killAllBalls)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Bridge" || collision.gameObject.tag == "PassedBridge")
        {
            bridgeScript = collision.gameObject.GetComponent<BridgeScript>();
            bridgeScript.currentBalls++;
            GameManager.instance.totalBalls ++;
            print(GameManager.instance.totalBalls);
            this.gameObject.GetComponentInChildren<ParticleSystem>().Play();

            this.gameObject.GetComponentInChildren<MeshRenderer>().enabled= false;
            StartCoroutine(DestroyMe());
            
        }
        print(gameObject.transform.localScale.x);

        //this.gameObject.tag = "Untagged";
        
        
        

    }
    IEnumerator DestroyMe()
    {
        yield return new WaitForSeconds(1.20f);
       
        this.gameObject.SetActive(false);
    }
}
