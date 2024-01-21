using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinSelector : MonoBehaviour
{
    public GameObject SkinsInterface;

    public void SelectSkin(int skinID)
    {
        print("We have selected the skin" + skinID);

        SkinsInterface.SetActive(false);
    }
}
