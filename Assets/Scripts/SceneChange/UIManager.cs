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

    public GameObject InfoUI;

    public Text highScore;
    public Text curScore;

    bool isSetting;
    public bool isSFX;
    bool isSound;
    bool isInfo;
    public bool isPause;

    public static UIManager instance=null;

    void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        if (PlayerPrefs.GetInt("isSFX") > 0) isSFX = true;
        else isSFX = false;
    }

    public void Ingame()
    {
        SceneManager.LoadScene("IngameScene");
        SoundMgr.instance.TouchSoundPlay();
    }

    public void Title()
    {
        SceneManager.LoadScene("TitleScene");
        SoundMgr.instance.TouchSoundPlay();

    }

    public void Setting()
    {
        isSetting = !isSetting;
        settingUI.SetActive(isSetting);
        SoundMgr.instance.TouchSoundPlay();

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
        SoundMgr.instance.TouchSoundPlay();

    }

    public void Pause()
    {
        isPause = !isPause;

        pauseUI.SetActive(isPause);
        SoundMgr.instance.TouchSoundPlay();


        if (isPause) Time.timeScale = 0;
        else Time.timeScale = 1;
    }

    public void Info()
    {
        isInfo = !isInfo;

        InfoUI.SetActive(isInfo);
        SoundMgr.instance.TouchSoundPlay();

    }

    void Update()
    {
        highScore.text = PlayerPrefs.GetInt("bestScore").ToString();
        if (PlayerPrefs.GetInt("isSFX") > 0) isSFX = true;
        else isSFX = false;
    }
}
