using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MainUI : MonoBehaviour
{
    public TextMeshProUGUI nbCoinsText;
    public int playerNbCoins;
    int binCoins;
    int intialPrice = 20;
    int coinsActualPrice;
    public TextMeshProUGUI coinsPriceText;
    public TextMeshProUGUI coinsLevelText;

    private void Awake()
    {
        playerNbCoins = PlayerPrefs.GetInt("nbCoins", 0);
        nbCoinsText.text = playerNbCoins.ToString();
        binCoins = PlayerPrefs.GetInt("coinsLevel", 1);
        coinsActualPrice = intialPrice * binCoins;
        coinsPriceText.text = coinsActualPrice + "PO";
    }

    public void IncrementCoinLevel()
    {
        if (playerNbCoins >= coinsActualPrice)
        {
            playerNbCoins -= coinsActualPrice;
            PlayerPrefs.SetInt("nbCoins", playerNbCoins);
            PlayerPrefs.SetInt("coinsLevel", PlayerPrefs.GetInt("coinsLevel", 1) +1);
            binCoins = PlayerPrefs.GetInt("coinsLevel", 1);
            coinsLevelText.text = "LEVEL " + PlayerPrefs.GetInt("coinsLevel", 1);
            coinsActualPrice = intialPrice * binCoins;
            coinsPriceText.text = coinsActualPrice + "PO";
        }
    }
}
