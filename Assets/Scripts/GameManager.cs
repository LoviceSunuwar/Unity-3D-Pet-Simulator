using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isGameStarted = false;

    public int level = 1;

    public GameObject[] rooms;

    public GameObject[] tutorial;

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
        }
    }

}
