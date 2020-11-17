using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyText : MonoBehaviour
{
    private Text myMoney;
    void Start()
    {
        myMoney = GameObject.Find("Money").GetComponent<Text>();
    }

    void Update()
    {
        SetMoney();
    }

    void SetMoney()
    {
        myMoney.text = ShopManager.userMoney.ToString();
    }
}
