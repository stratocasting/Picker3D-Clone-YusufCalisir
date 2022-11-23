using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField] float camPosZ = 12;
    void Awake()
    {
        transform.position = new Vector3(0, transform.position.y, player.transform.position.z - camPosZ);
    }
    void LateUpdate()
    {
        transform.position = new Vector3(0, transform.position.y, player.transform.position.z - camPosZ);
    }
}
