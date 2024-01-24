using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool isGameStarted = false;

    public bool isGameEnded = false;

    public TextMeshProUGUI textTimer;

    public int level = 1;

    public GameObject[] rooms;

    public GameObject[] tutorial;

    public GameObject ScreenEnd;

    public int timerFull = 30;

    public TextMeshProUGUI textScoreFinal;

    public TextMeshProUGUI textScoreBest;

    public TextMeshProUGUI textScore;


    private void Awake()
    {
        timerFull = 30; // manually defining the value forcing so that we are not efffected by oncoming bugs
        for (int i = 0; i < rooms.Length; i++)
        {
            if (i < level)
            {
                rooms[i].SetActive(true);
            }
            else
            {
                rooms[i].SetActive(false);
            }
        }

        textScoreBest.text = "Best Score: " + PlayerPrefs.GetInt("scoreMax", 0);
    }

    private void Update()
    {
        // This function allows the user to start the game whne the screen is touched.
        //if (Input.GetMouseButton(0) && !isGameStarted)
        //{
        //    isGameStarted = true;
        //    tutorial[0].SetActive(false);
        //    InvokeRepeating("SetTimer", 1, 1);

        //}
    }

    public void startGame()
    {
        isGameStarted = true;
        tutorial[0].SetActive(false);
        InvokeRepeating("SetTimer", 1, 1);

    }

    public void SetTimer()
    {
        timerFull--;
        textTimer.text = timerFull.ToString();
        // If the game is over logic // game end logic
        if (timerFull == 0)
        {
            isGameEnded = true;
            CancelInvoke(); // This funciton will cancel all the invoke that are called for the conatining function
            ScreenEnd.SetActive(true);
            textScoreFinal.text = "Score: " + textScore.text;

        }
    }

    public void RestartGame()
    {
        int scoreCurrent = int.Parse(textScore.text);
        int scoreMax = PlayerPrefs.GetInt("scoreMax", 0);

        if ( scoreCurrent > scoreMax)
        {
            PlayerPrefs.SetInt("scoreMax", scoreCurrent);
        }
        timerFull = 30; // reseting the value again.
        Application.LoadLevel(Application.loadedLevelName); // This allows to load the level , in this case last one that was loaded.
        
     

    }
    public void WatchAds()
    {
        // TODO: Show the video ads.
        // TODO: Detect ads scene
        GetExtraTime();
    }

    public void GetExtraTime()
    {
        timerFull = 10 + PlayerPrefs.GetInt("timerLevel", 1);
        textTimer.text = timerFull.ToString();
        InvokeRepeating("SetTimer", 1, 1);
        isGameEnded = false;
        ScreenEnd.SetActive(false);
    }

   

}
