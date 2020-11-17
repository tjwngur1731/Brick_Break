﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BrickManager : MonoBehaviour
{
    public GameObject[] n;

    public Text bestScore;
    public Text score;

    AudioSource audio;
    AudioSource move;

    public GameObject sound;


    int x, y, i;
    int curScore, highScore;
    bool chk;
    bool isSFX;
    int ra;

    int cnttt;

    GameObject[,] Square;
    // Start is called before the first frame update
    void Start()
    {
        Square = new GameObject[7, 7];
        highScore = PlayerPrefs.GetInt("highScore");
        audio = GetComponent<AudioSource>();
        move = sound.GetComponent<AudioSource>();
        Spawn();
        Spawn();
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("isSFX") > 0) isSFX = true;
        else isSFX = false;
        score.text = curScore.ToString();
        bestScore.text = highScore.ToString();
        PlayerPrefs.SetInt("highScore", highScore);
        if (curScore > highScore) highScore = curScore;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // 일시정지
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && !UIManager.instance.isPause)
        {
            for (x = 0; x <= 6; x++)
                for (y = 0; y <= 5; y++)
                    for (i = 6; i >= y + 1; i--)
                        BrickMove(x, i - 1, x, i);
            Spawn();
            if(isSFX) move.Play();
            BrickCheck();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && !UIManager.instance.isPause)
        {
            for (x = 0; x <= 6; x++)
                for (y = 6; y >= 1; y--)
                    for (i = 0; i <= y - 1; i++)
                        BrickMove(x, i + 1, x, i);
            Spawn();
            if(isSFX) move.Play();

            BrickCheck();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && !UIManager.instance.isPause)
        {
            for (y = 0; y <= 6; y++)
                for (x = 0; x <= 5; x++)
                    for (i = 6; i >= x + 1; i--)
                        BrickMove(i - 1, y, i, y);
            Spawn();
            if (isSFX) move.Play();


            BrickCheck();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && !UIManager.instance.isPause)
        {
            for (y = 0; y <= 6; y++)
                for (x = 6; x >= 1; x--)
                    for (i = 0; i <= x - 1; i++)
                        BrickMove(i + 1, y, i, y);
            Spawn();
            if (isSFX) move.Play();


            BrickCheck();    
        }

    }

    void BrickCheck()
    {
        for (int xx = 0; xx < 7; xx++)
        {
            for (int yy = 0; yy < 6; yy++)
            {
                if (Square[xx, yy] == null || Square[xx, yy + 1] == null)
                {
                    chk = false;
                    break;
                }

                else if (Square[xx,yy].tag==Square[xx,yy+1].tag)
                {
                    chk = true;
                }
                else
                {
                    chk = false;
                    break;
                }
            }
            if(chk) BrickBreak(xx,false);
        }
        
        for(int yy=0;yy<7;yy++)
        {
            for(int xx = 0; xx<6;xx++)
            {
                if (Square[xx, yy] == null || Square[xx + 1, yy] == null)
                {
                    chk = false;
                    break;
                }

                else if (Square[xx, yy].tag == Square[xx + 1, yy].tag)
                {
                    chk = true;
                }

                else
                {
                    chk = false;
                    break;
                }
            }
            if (chk) BrickBreak(yy, true);
        }
        
    }

    void BrickBreak(int line, bool isHorizontal)
    {

        if (isHorizontal)
        {
            for (int ii = 0; ii < 7; ii++)
            {
                Destroy(Square[ii, line]);
            }
        }
        else
        {
            for (int ii = 0; ii < 7; ii++)
            {
                Destroy(Square[line, ii]);
            }
        }
        Debug.Log("BREAK!");
        if (isSFX) audio.Play();
        curScore++;
    }

    void BrickMove(int x1, int y1, int x2, int y2)
    {
        if (Square[x2, y2] == null && Square[x1, y1] != null)
        {
            Square[x1, y1].GetComponent<Moving>().Move(x2, y2);
            Square[x2, y2] = Square[x1, y1];
            Square[x1, y1] = null;
        }
        
    }


    void Spawn()
    {
        while (true)
        {
            cnttt = 0;

            x = Random.Range(0, 7);
            y = Random.Range(0, 7);

            if (Square[x, y] == null)
                break;

            for (int ii = 0; ii < 7; ii++)
            {
                for (int jj = 0; jj < 7; jj++)
                {
                    if(Square[ii,jj] != null)
                    {
                        cnttt++;
                    }
                }
            }
            if (cnttt >= 48)
            {

            }
        }

        ra = Random.Range(0, 10);

        if (ra > 0) ra = 1;

        if (Square[x, y] == null)
        {
            Square[x, y] = Instantiate(n[ra], new Vector3(0.75f * x -2.25f, -0.75f * y + 1.5f, 0), Quaternion.identity);
        }
    }

}
