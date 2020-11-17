using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject pauseUI;

    public GameObject settingUI;

    public GameObject[] SFXUI;

    public GameObject[] SoundUI;

    public Text highScore;

    bool isSetting;
    bool isSFX;
    bool isSound;
    public bool isPause;

    public static UIManager instance=null;

    void Awake()
    {
        if (!instance) instance = this;
    }

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
        isSetting = !isSetting;
        settingUI.SetActive(isSetting);
    }

    public void SFX()
    {
        if (PlayerPrefs.GetInt("isSFX") > 0) isSFX = true;
        else isSFX = false;
        isSFX = !isSFX;
        SFXUI[1].SetActive(isSFX);
        SFXUI[0].SetActive(!isSFX);
        PlayerPrefs.SetInt("isSFX", isSFX ? 1:0);
    }

    public void Sound()
    {
        isSound = !isSound;
        SoundUI[1].SetActive(isSound);
        SoundUI[0].SetActive(!isSound);
    }



    public void Skin()
    {
        SceneManager.LoadScene("Skins");
    }

    public void Pause()
    {
        isPause = !isPause;

        pauseUI.SetActive(isPause);

        if (isPause) Time.timeScale = 0;
        else Time.timeScale = 1;
    }

    void Update()
    {
        highScore.text = PlayerPrefs.GetInt("highScore").ToString();
    }
}
