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

    public GameObject[] VibrateUI;

    public GameObject noAds;

    public GameObject ingameBtn;
    public GameObject titleBtn;
    public GameObject settingBtn;
    public GameObject[] sfxBtn;
    public GameObject[] vibrateBtn;
    public GameObject noadsBtn;
    public GameObject skinBtn;
    public GameObject pauseBtn;

    public Text highScore;
    public Text curScore;
    public Text money;

    bool isSetting;
    public bool isSFXOn;
    bool isSound;
    bool isInfo;
    public bool isVibrate;
    public bool isPause;

    Vector3 scaleup;

    public static UIManager instance=null;

    void Awake()
    {


        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        if (PlayerPrefs.GetInt("isSFXOn") != 0) isSFXOn = true;
        else isSFXOn = false;

        if (PlayerPrefs.GetInt("isVibrate") != 0) isVibrate = true;
        else isVibrate = false;

        if (PlayerPrefs.GetInt("highScore") == 0)
        {
            isSFXOn = true;
            isVibrate = true;
        }
        

        

        scaleup = new Vector3(.1f, .1f, .1f);
    }

    private void Start()
    {
        //VibrateUI[0].SetActive(isVibrate);
        //VibrateUI[1].SetActive(!isVibrate);

        //SFXUI[1].SetActive(isSFXOn);
        //SFXUI[0].SetActive(!isSFXOn);

        Time.timeScale = 1;
    }

    public void Ingame()
    {
        SceneManager.LoadScene("IngameScene");
        SoundMgr.instance.TouchSoundPlay();

        StartCoroutine(ButtonEffect(ingameBtn));
    }

    public void Title()
    {
        SceneManager.LoadScene("TitleScene");
        SoundMgr.instance.TouchSoundPlay();

        StartCoroutine(ButtonEffect(titleBtn));

    }

    public void Setting()
    {
        isSetting = !isSetting;
        settingUI.SetActive(isSetting);
        SoundMgr.instance.TouchSoundPlay();

        StartCoroutine(ButtonEffect(settingBtn));

    }

    public void SFX()
    {
        isSFXOn = !isSFXOn;
        SFXUI[1].SetActive(isSFXOn);
        SFXUI[0].SetActive(!isSFXOn);
        PlayerPrefs.SetInt("isSFXOn", isSFXOn ? 1 : 0);
        SoundMgr.instance.TouchSoundPlay();

        StartCoroutine(ButtonEffect(sfxBtn[1]));
        StartCoroutine(ButtonEffect(sfxBtn[0]));

    }

    public void Vibrate()
    {
        isVibrate = !isVibrate;
        VibrateUI[0].SetActive(isVibrate);
        VibrateUI[1].SetActive(!isVibrate);
        PlayerPrefs.SetInt("isVibrate", isVibrate ? 1 : 0);
        SoundMgr.instance.TouchSoundPlay();

        StartCoroutine(ButtonEffect(vibrateBtn[1]));
        StartCoroutine(ButtonEffect(vibrateBtn[0]));
    }

    public void NoAds()
    {
        noAds.SetActive(!noAds.activeSelf);
        SoundMgr.instance.TouchSoundPlay();

        StartCoroutine(ButtonEffect(noadsBtn));

    }



    public void Skin()
    {
        SceneManager.LoadScene("SkinScene");
        SoundMgr.instance.TouchSoundPlay();

        StartCoroutine(ButtonEffect(skinBtn));

    }

    public void Pause()
    {
        isPause = !isPause;

        pauseUI.SetActive(isPause);
        SoundMgr.instance.TouchSoundPlay();


        if (isPause) Time.timeScale = 0;
        else Time.timeScale = 1;


        StartCoroutine(ButtonEffect(pauseBtn));

    }



    void Update()
    {
        highScore.text = PlayerPrefs.GetInt("bestScore_").ToString();
        money.text = PlayerPrefs.GetInt("money").ToString();
    }

    IEnumerator ButtonEffect(GameObject obj)
    {
        obj.transform.localScale = obj.transform.localScale + scaleup;

        yield return new WaitForSeconds(.1f);

        obj.transform.localScale = obj.transform.localScale - scaleup;
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
