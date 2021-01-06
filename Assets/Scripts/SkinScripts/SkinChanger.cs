using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinChanger : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.GetInt("Skins");
    }
}
