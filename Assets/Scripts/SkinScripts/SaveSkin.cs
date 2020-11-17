using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSkin : MonoBehaviour
{
    int currentSkin;
    public GameObject[] obj;
    void Start()
    {
        currentSkin = PlayerPrefs.GetInt("Skin");
    }

    void Update()
    {
        SkinAvailble();
    }
    public void SkinAvailble()
    {
        for (int i = 0; i < obj.Length; i++)
        {
            obj[i].SetActive(false);
        }
        obj[currentSkin].SetActive(true);
        
    }
}
