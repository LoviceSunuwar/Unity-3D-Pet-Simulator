using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool isGameStarted = false;

    public TextMeshProUGUI textscore;

    public int level = 1;

    public GameObject[] rooms;

    public GameObject[] tutorial;

    public GameObject ScreenEnd;

    int timerFull = 30;


    private void Awake()
    {
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
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && !isGameStarted)
        {
            isGameStarted = true;
            tutorial[0].SetActive(false);
            InvokeRepeating("SetTimer", 1, 1);

        }
    }

    public void SetTimer()
    {
        timerFull--;
        textscore.text = timerFull.ToString();
    }

    public void RestartGame()
    {
        Application.LoadLevel(Application.loadedLevelName); // This allows to load the level , in this case last one that was loaded.

    }

}
