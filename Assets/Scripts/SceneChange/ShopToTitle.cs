using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopToTitle : MonoBehaviour
{
    void Start()
    {
        
    }

    public void MouseGetButton()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
