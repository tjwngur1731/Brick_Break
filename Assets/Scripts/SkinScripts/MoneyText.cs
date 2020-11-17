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
        myMoney.text = userMoney.ToString();
        PlayerPrefs.SetInt("Money", ShopManager.instance.userMoney);

    }
}
