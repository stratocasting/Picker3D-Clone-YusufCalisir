using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI currentLevelObj;
    [SerializeField] TextMeshProUGUI nextLevelObj;
    public float measureToEnd;
    public float measureToEnd2;
    [SerializeField] GameObject FinishMeasureItem;
    [SerializeField] GameObject player;
    [SerializeField] Image arrowBar;
    public int currentLevel;
    public int nextLevel;
    [SerializeField] GameObject uiGameOverScreen;
    [SerializeField] GameObject panel;
    [SerializeField] TextMeshProUGUI noThnaks;
    [SerializeField] TextMeshProUGUI levelStatus;
    [SerializeField] GameObject LevelComplObj;
    [SerializeField] GameObject Adsobj;
    public bool levelEnd;
    [SerializeField] TextMeshProUGUI diamonAmount;
    [SerializeField] GameObject sadEmoji;
    [SerializeField] GameObject happyEmoji;
    // Start is called before the first frame update
    void Start()
    {

        currentLevel = SceneManager.GetActiveScene().buildIndex + 1;
        nextLevel = currentLevel + 1;
        currentLevelObj.text = currentLevel.ToString();
        nextLevelObj.text = nextLevel.ToString();

        measureToEnd = FinishMeasureItem.transform.position.z - player.transform.position.z ;
        measureToEnd2 = measureToEnd;


        
    }


    // Update is called once per frame
    void Update()
    {

        measureToEnd = FinishMeasureItem.transform.position.z - player.transform.position.z/measureToEnd2*100;
        
        arrowBar.fillAmount = measureToEnd/110;
        if (PlayerMovement.instance.gameOver)
        {
            noThnaks.text = "NO THANKS, RESTART";
            uiGameOverScreen.SetActive(true);
            panel.SetActive(true);
            sadEmoji.SetActive(true);
            happyEmoji.SetActive(false);
        }
        if (PlayerMovement.instance.finish)
        {
            levelEnd = true;
            LevelEnded();
        }
    }
    public void Restart()
    {
        if(levelEnd)
        {
            if (SceneManager.GetActiveScene().buildIndex != 4)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }
        else
        {
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
    }
    public void Ads()
    {
        Debug.Log("ads reloading");
    }
    public void LevelEnded()
    {
        diamonAmount.text = GameManager.instance.totalBalls.ToString();
        sadEmoji.SetActive(false);
        happyEmoji.SetActive(true );
        Adsobj.SetActive(false);
        LevelComplObj.SetActive(true) ;
        levelStatus.text = "LEVEL COMPLETE";
        noThnaks.text = "NO THANKS, CONTINUE";
        uiGameOverScreen.SetActive(true);
        panel.SetActive(true);
    }
}
