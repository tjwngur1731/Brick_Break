using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinChoose : MonoBehaviour
{
    public GameObject[] obj;

    public void SkinAvailble()
    {
        for (int i = 0; i < obj.Length; i++)
        {
            Debug.Log(ShopManager.instance.buySkin[i]);

            if (ShopManager.instance.buySkin[i])
            {
                for (int j = 0; j < obj.Length; j++)
                {
                    obj[j].SetActive(false);
                }
                obj[i].SetActive(true);
                PlayerPrefs.SetInt("Skin",i);
                int a = PlayerPrefs.GetInt("Skin");
                Debug.Log(i);
            }
            
        }
    }
}
