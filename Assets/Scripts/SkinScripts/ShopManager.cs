using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    int[] skinPrice;
    public int userMoney;
    List<string> userInven = new List<string>();
    public bool[] buySkin;

    public static ShopManager instance = null;

    void Awake()
    {
        if (!instance)
            instance = this;
    }

    void Start()
    {
        skinPrice = new int[6];
        buySkin = new bool[6];
        for (int i = 0; i < buySkin.Length; i++)
        {
            buySkin[i] = false;
        }
        skinPrice[0] = 100;
        skinPrice[1] = 100;
        skinPrice[2] = 100;
        skinPrice[3] = 100;
        skinPrice[4] = 100;
        skinPrice[5] = 100;
        userMoney = PlayerPrefs.GetInt("Money");
    }

    public void BuySkin(int index)
    {
        for (int i = 0; i < buySkin.Length; i++)
        {
            buySkin[i] = false;
        }
        buySkin[index] = true;
        userMoney -= skinPrice[index];
        PlayerPrefs.SetInt("Money", userMoney);

        Debug.Log("구매 : " + buySkin[index]);
    }
}
