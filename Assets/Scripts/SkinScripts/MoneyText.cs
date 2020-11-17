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
<<<<<<< HEAD
        myMoney.text = "<color=#ff0000>" + userMoney.ToString() + "</color>";
        PlayerPrefs.SetInt("Money", ShopManager.userMoney);
=======
        //myMoney.text = userMoney.ToString();
        //PlayerPrefs.SetInt("Money", ShopManager.instance.userMoney);

>>>>>>> 23d3456d7838489d286cc56904c3aac3852d8236
    }
}
