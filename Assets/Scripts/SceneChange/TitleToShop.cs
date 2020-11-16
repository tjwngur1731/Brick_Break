using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleToShop : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        GetMouseButton();
    }

    public void GetMouseButton()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Shop");
        }
    }
}
