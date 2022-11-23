using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigBall : MonoBehaviour
{
    public GameObject spawnBall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            print("yeni toplar geliyor");
            Instantiate(spawnBall, gameObject.transform.position, Quaternion.identity);
            Instantiate(spawnBall, new Vector3(gameObject.transform.position.x + .70f, gameObject.transform.position.y, gameObject.transform.position.z) , Quaternion.identity);
            Instantiate(spawnBall, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z+1.70f), Quaternion.identity);
            Instantiate(spawnBall, new Vector3(gameObject.transform.position.x - .70f, gameObject.transform.position.y, gameObject.transform.position.z + 1.70f), Quaternion.identity);

            Destroy(gameObject);
        }
            
        
    }
}
