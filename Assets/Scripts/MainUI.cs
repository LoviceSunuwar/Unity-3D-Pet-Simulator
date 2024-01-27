using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MainUI : MonoBehaviour
{
    public TextMeshProUGUI nbCoinsText;
    //public TextMeshProUGUI nbSpeedText;
    //public TextMeshProUGUI nbTimerText;
    public int playerNbCoins;
    int binCoins;
    int binSpeed;
    int binTimer;
    int intialPrice = 20;
    int coinsActualPrice;
    int speedActualPrice;
    int timerActualPrice;
    public TextMeshProUGUI coinsPriceText;
    public TextMeshProUGUI coinsLevelText;
    public TextMeshProUGUI speedPriceText;
    public TextMeshProUGUI speedLevelText;
    public TextMeshProUGUI timerPriceText;
    public TextMeshProUGUI timerLevelText;

    private void Awake()
    {
        playerNbCoins = PlayerPrefs.GetInt("nbCoins", 0);
        nbCoinsText.text = playerNbCoins.ToString();
        onAwakeCoinLevel();
        onAwakeSpeedLevel();
        onAwakeTimerLevel();
    }

    public void onAwakeCoinLevel()
    {
        binCoins = PlayerPrefs.GetInt("coinsLevel", 1);
        coinsActualPrice = intialPrice * binCoins;
        coinsPriceText.text = coinsActualPrice + "PO";
        coinsLevelText.text = "LEVEL " + PlayerPrefs.GetInt("coinsLevel", 1);

    }


    public void IncrementCoinLevel()
    {
        if (playerNbCoins >= coinsActualPrice)
        {
            playerNbCoins -= coinsActualPrice;
            PlayerPrefs.SetInt("nbCoins", playerNbCoins);
            nbCoinsText.text = playerNbCoins.ToString();
            PlayerPrefs.SetInt("coinsLevel", PlayerPrefs.GetInt("coinsLevel", 1) +1);
            binCoins = PlayerPrefs.GetInt("coinsLevel", 1);
            coinsLevelText.text = "LEVEL " + PlayerPrefs.GetInt("coinsLevel", 1);
            coinsActualPrice = intialPrice * binCoins;
            coinsPriceText.text = coinsActualPrice + "PO";
        }
    }

    public void onAwakeSpeedLevel()
    {
        binSpeed = PlayerPrefs.GetInt("speedLevel", 1);
        speedActualPrice = intialPrice * binSpeed;
        speedPriceText.text = speedActualPrice + "PO";
        speedLevelText.text = "LEVEL " + PlayerPrefs.GetInt("speedLevel", 1);
    }


    public void IncrementSpeedLevel()
    {
        if (playerNbCoins >= speedActualPrice)
        {
            playerNbCoins -= speedActualPrice;
            PlayerPrefs.SetInt("nbCoins", playerNbCoins);
            nbCoinsText.text = playerNbCoins.ToString();
            PlayerPrefs.SetInt("speedLevel", PlayerPrefs.GetInt("speedLevel", 1) + 1);
            binSpeed = PlayerPrefs.GetInt("speedLevel", 1);
            speedLevelText.text = "LEVEL " + PlayerPrefs.GetInt("speedLevel", 1);
            speedActualPrice = intialPrice * binSpeed;
            speedPriceText.text = speedActualPrice + "PO";
        }
    }

    public void onAwakeTimerLevel()
    {
        binTimer = PlayerPrefs.GetInt("timerLevel", 1);
        timerActualPrice = intialPrice * binTimer;
        timerPriceText.text = timerActualPrice + "PO";
        timerLevelText.text = "LEVEL " + PlayerPrefs.GetInt("timerLevel", 1);
    }


    public void IncrementTimerLevel()
    {
        if (playerNbCoins >= timerActualPrice)
        {
            playerNbCoins -= timerActualPrice;
            PlayerPrefs.SetInt("nbCoins", playerNbCoins);
            nbCoinsText.text = playerNbCoins.ToString();
            PlayerPrefs.SetInt("timerLevel", PlayerPrefs.GetInt("timerLevel", 1) + 1);
            binTimer = PlayerPrefs.GetInt("timerLevel", 1);
            timerLevelText.text = "LEVEL " + PlayerPrefs.GetInt("timerLevel", 1);
            timerActualPrice = intialPrice * binTimer;
            timerPriceText.text = timerActualPrice + "PO";
        }
    }
}
