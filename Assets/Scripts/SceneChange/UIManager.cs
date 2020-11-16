using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject pauseUI;

    public void Ingame()
    {
        SceneManager.LoadScene("IngameScene");
    }

    public void Title()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void Setting()
    {
    }

    public void Skin()
    {
        SceneManager.LoadScene("Skins");
    }

    public void Pause()
    {
        pauseUI.SetActive(true);

    }
}
