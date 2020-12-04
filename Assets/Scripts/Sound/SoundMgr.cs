﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMgr : MonoBehaviour
{

    AudioSource moveSound;
    AudioSource breakSound;
    AudioSource overSound;
    AudioSource startSound;
    AudioSource touchSound;

    public GameObject moveSoundObj;
    public GameObject breakSoundObj;
    public GameObject overSoundObj;
    public GameObject startSoundObj;
    public GameObject touchSoundObj;

    public static SoundMgr instance = null;
    void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);


    }

    void Start()
    {
        moveSound = moveSoundObj.GetComponent<AudioSource>();
        breakSound = breakSoundObj.GetComponent<AudioSource>();
        overSound = overSoundObj.GetComponent<AudioSource>();
        startSound = startSoundObj.GetComponent<AudioSource>();
        touchSound = touchSoundObj.GetComponent<AudioSource>();
    }


    public void MoveSoundPlay()
    {
        if (UIManager.instance.isSFX)
            moveSound.Play();
    }

    public void BreakSoundPlay()
    {
        if (UIManager.instance.isSFX)
            breakSound.Play();
    }

    public void OverSoundPlay()
    {
        if (UIManager.instance.isSFX)
            overSound.Play();
    }

    public void StartSoundPlay()
    {
        if (UIManager.instance.isSFX)
            startSound.Play();
    }

    public void TouchSoundPlay()
    {
        if (UIManager.instance.isSFX)
            touchSound.Play();
    }

}
