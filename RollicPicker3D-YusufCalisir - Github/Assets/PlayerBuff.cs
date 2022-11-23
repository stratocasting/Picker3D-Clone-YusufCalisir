using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuff : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Vector3 _rotating;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(_rotating * Time.deltaTime);
        //transform.position = new Vector3(0, 0, 0);
        //LeanTween.rotateAround(gameObject, new Vector3(0, 50, 0), 1, 1).setOnCompleteOnRepeat(true);
        //LeanTween.rotateLocal(gameObject, 50, 1);
        //LeanTween.rotateLocal(gameObject, new Vector3(0,15,0), .1f);
        //LeanTween.rotateY(gameObject, 360.0f, 1.0f).setRepeat(999);
        //transform.Rotate(Vector3.up, Time.deltaTime * RotateSpeed);
        //LeanTween.rotateAround(gameObject, Vector3.up, 360, 2.5f).setLoopClamp();
    }
}
