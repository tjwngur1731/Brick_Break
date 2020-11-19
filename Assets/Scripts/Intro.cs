using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    public GameObject game;

    public GameObject adsf;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SceneChange", 2);
        adsf.SetActive(false);
        Screen.SetResolution(540, 960, false);
    }
    void SceneChange()
    {
        game.SetActive(false);

        Invoke("SceneChange2", 3);
    }

    void SceneChange2()
    {
        SceneManager.LoadScene("TitleScene");

    }
}
