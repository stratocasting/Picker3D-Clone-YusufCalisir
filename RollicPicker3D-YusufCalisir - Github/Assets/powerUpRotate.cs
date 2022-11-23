using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUpRotate : MonoBehaviour
{
    Vector3 _rotating = new Vector3(0,100,0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(_rotating * Time.deltaTime);
    }
    
}
