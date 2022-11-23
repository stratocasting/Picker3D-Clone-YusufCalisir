using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static GameManager Instance { get { return instance; } }
    public int totalBalls;

    [SerializeField] public int currentBalls;
    void Awake()
    {
        instance = this;
    }
    void Start()
    {

    }

    
}
