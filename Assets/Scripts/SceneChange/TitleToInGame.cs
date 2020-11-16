using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleToInGame : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        MouseGetButton();
    }
    public void MouseGetButton()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("IngameScene");
        }
    }
}
