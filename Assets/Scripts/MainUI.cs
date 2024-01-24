using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MainUI : MonoBehaviour
{
    public TextMeshProUGUI nbCoinsText;

    private void Awake()
    {
        nbCoinsText.text = PlayerPrefs.GetInt("nbCoins", 0).ToString();
    }
}
