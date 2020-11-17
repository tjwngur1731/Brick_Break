using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyText : MonoBehaviour
{
    private Text myMoney;
    int userMoney;
    void Start()
    {
        
        myMoney = GameObject.Find("Money").GetComponent<Text>();
        userMoney = PlayerPrefs.GetInt("Money");
    }

    void Update()
    {
        SetMoney();
        userMoney = PlayerPrefs.GetInt("Money");
    }

    void SetMoney()
    {
        myMoney.text = "<color=#ff0000>" + userMoney.ToString() + "</color>";
        PlayerPrefs.SetInt("Money", ShopManager.userMoney);
    }
}
