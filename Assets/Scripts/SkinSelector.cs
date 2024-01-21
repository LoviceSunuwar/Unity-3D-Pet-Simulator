using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinSelector : MonoBehaviour
{
    public GameObject SkinsInterface;

    public FoxSkin fx;

    public void SelectSkin(int skinID)
    {
        print("We have selected the skin" + skinID);
        PlayerPrefs.SetInt("selectedSkin", skinID); // Saving in the memory
        fx.SetSkin(skinID);
        SkinsInterface.SetActive(false);
    }
}
