using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxSkin : MonoBehaviour
{
    public Texture[] skins;
    public Material foxMaterial;
    public int selectedSkin;

    private void Awake()
    {
        // Player prefs is a class that allows to save the user data from the device.
        selectedSkin = PlayerPrefs.GetInt("selectedSkin", 0); // Keeping a default value of 0

        foxMaterial.mainTexture = skins[selectedSkin]; // gets the id from the selected skin and apply on the material
    }

    public void SetSkin(int skinID)
    {
        foxMaterial.mainTexture = skins[skinID]; // using the selected skin.
    }

}
