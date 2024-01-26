using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockBonusItem : MonoBehaviour
{
    public int daysPlayed;
    public Button skin2Btn;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.GetInt("DaysPlayed");
        if (daysPlayed >= 3)
            // Assuming we unlock the skin in the third day
        {
            PlayerPrefs.SetInt("Skins2_Unlocked", 1);
            skin2Btn.interactable = true;
        }
    }

    
}
