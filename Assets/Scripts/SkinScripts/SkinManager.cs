using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinManager : MonoBehaviour
{
    public GameObject background;
    public GameObject block;

    Image image;
    Image blockImg;

    public Sprite[] sprite;
    public Sprite[] blockSprite;

    int skinNum;

    public static SkinManager instance = null; 

    void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);


        background = GameObject.FindGameObjectWithTag("Background");
        block = GameObject.Find("Block");
        image = background.GetComponent<Image>();
        if (block != null)
            blockImg = block.GetComponent<Image>();

        skinNum = PlayerPrefs.GetInt("SkinNum");

    }

    void Start()
    {
        image.sprite = sprite[skinNum];

        blockImg.sprite = blockSprite[skinNum];
    }

    public void SkinChange(int skin)
    {
        image.sprite = sprite[skin];
        Debug.Log(skin);
        PlayerPrefs.SetInt("SkinNum", skin);
        SoundMgr.instance.TouchSoundPlay();
    }
}
