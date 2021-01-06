using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BrickManager : MonoBehaviour
{
    public GameObject[] n;

    public Text bestScore;
    public Text score;
    public Text curScore2;


    public GameObject gameover;
    public GameObject orangeTuto;
    public GameObject blueTuto;

    float blueDelay;

    public GameObject orangeEffect;
    public GameObject blueEffect;

    float arrowDelay;
    float curDelay;


    public GameObject arrow;
    SpriteRenderer sr;
    public GameObject trail;
    TrailRenderer tr;
    public GameObject firstPlayObj;

    private Vector3 fp;
    private Vector3 lp;
    private float dragDistance;


    int x, y, i;
    int curScore, highScore;
    bool chk;
    bool isSFX;
    bool isGameover;
    bool isBreaking;
    bool firstPlay;
    bool firstBlue;
    int ra;

    int blueCnt;

    int cnttt;

    GameObject[,] Square;

    void Awake()
    {
        if (PlayerPrefs.GetInt("bestScore_") == 0) firstPlay = true;
        else firstPlay = false;
#if UNITY_EDITOR
        firstPlay = true;
#endif

        firstBlue = firstPlay;

        firstPlayObj.SetActive(firstPlay);
        orangeTuto.SetActive(firstPlay);

        arrowDelay = 1f;
    }
    void Start()
    {
        dragDistance = Screen.height * 7 / 100;

        tr = trail.GetComponent<TrailRenderer>();
        sr = arrow.GetComponent<SpriteRenderer>();

        Square = new GameObject[7, 7];
        highScore = PlayerPrefs.GetInt("bestScore_");


        SoundMgr.instance.StartSoundPlay();

        if (!firstPlay)
        {
            Spawn();
            Spawn();
            Spawn();
        }
        else
        {
            FirstSpawn();
        }

    }

    // Update is called once per frame
    void Update()
    {
        curDelay += Time.deltaTime;

        arrow.transform.position = Vector3.Lerp(arrow.transform.position, new Vector3(1f, -2f, 0), Time.deltaTime * 1);
        sr.color = new Color(255,255,255, Mathf.MoveTowards(sr.color.a, .5f, Time.deltaTime * .3f));

        if (blueTuto.activeSelf)
        {
            blueDelay += Time.deltaTime;
            if (blueDelay >= 5)
                blueTuto.SetActive(false);
        }

        if (curDelay >= arrowDelay)
        {
            arrow.transform.position = new Vector3(1f, -0f, 0);
            curDelay = 0;
            sr.color = Color.white;
            tr.Clear();
        }

        if (PlayerPrefs.GetInt("isSFX") > 0) isSFX = true;
        else isSFX = false;
        score.text = curScore.ToString();
        bestScore.text = highScore.ToString();
        curScore2.text = curScore.ToString();
        PlayerPrefs.SetInt("bestScore_", highScore);
        if (curScore > highScore) highScore = curScore;
        score.text = curScore.ToString();
        if (PlayerPrefs.GetInt("isSFX") > 0) isSFX = true;
        else isSFX = false;

#if UNITY_ANDROID
        if (Input.touchCount == 1 && !isBreaking) // user is touching the screen with a single touch
        {
            Touch touch = Input.GetTouch(0); // get the touch
            if (touch.phase == TouchPhase.Began) //check for the first touch
            {
                fp = touch.position;
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved) // update the last position based on where they moved
            {
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended) //check if the finger is removed from the screen
            {
                lp = touch.position;  //last touch position. Ommitted if you use list

                //Check if drag distance is greater than 20% of the screen height
                if (Mathf.Abs(lp.x - fp.x) > dragDistance || Mathf.Abs(lp.y - fp.y) > dragDistance)
                {//It's a drag
                 //check if the drag is vertical or horizontal
                    if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y))
                    {   //If the horizontal movement is greater than the vertical movement...
                        if ((lp.x > fp.x))  //If the movement was to the right)
                        {   //Right swipe
                            if (!firstPlay)
                                MoveRight();
                        }
                        else
                        {   //Left swipe
                            if (!firstPlay)
                                MoveLeft();
                        }
                    }
                    else
                    {   //the vertical movement is greater than the horizontal movement
                        if (lp.y > fp.y)  //If the movement was up
                        {   //Up swipe
                            if (!firstPlay)
                                MoveUp();
                        }
                        else
                        {   //Down swipe
                                MoveDown();
                        }
                    }
                }
                else
                {   //It's a tap as the drag distance is less than 20% of the screen height
                    Debug.Log("Tap");
                }
            }
        }



#elif UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.DownArrow) && !UIManager.instance.isPause && !isBreaking)
        {
            MoveDown();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && !UIManager.instance.isPause && !isBreaking)
        {
            if (!firstPlay)
                MoveUp();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && !UIManager.instance.isPause && !isBreaking)
        {
            if (!firstPlay)
                MoveRight();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && !UIManager.instance.isPause && !isBreaking)
        {
            if (!firstPlay)
                MoveLeft();
        }
#endif
    }


    void MoveDown()
    {

        for (x = 0; x <= 6; x++)
            for (y = 0; y <= 5; y++)
                for (i = 6; i >= y + 1; i--)
                    BrickMove(x, i - 1, x, i);
        Spawn();
        if (isSFX) SoundMgr.instance.MoveSoundPlay();
        BrickCheck();
    }
    void MoveUp()
    {
        for (x = 0; x <= 6; x++)
            for (y = 6; y >= 1; y--)
                for (i = 0; i <= y - 1; i++)
                    BrickMove(x, i + 1, x, i);
        Spawn();
        if (isSFX) SoundMgr.instance.MoveSoundPlay();

        BrickCheck();
    }

    void MoveRight()
    {
        for (y = 0; y <= 6; y++)
            for (x = 0; x <= 5; x++)
                for (i = 6; i >= x + 1; i--)
                    BrickMove(i - 1, y, i, y);
        Spawn();
        if (isSFX) SoundMgr.instance.MoveSoundPlay();


        BrickCheck();
    }

    void MoveLeft()
    {
        for (y = 0; y <= 6; y++)
            for (x = 6; x >= 1; x--)
                for (i = 0; i <= x - 1; i++)
                    BrickMove(i + 1, y, i, y);
        Spawn();
        if (isSFX) SoundMgr.instance.MoveSoundPlay();


        BrickCheck();
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

                else if (Square[xx, yy].tag == Square[xx, yy + 1].tag)
                {
                    chk = true;
                }
                else
                {
                    chk = false;
                    break;
                }
            }
            if (chk) StartCoroutine(BrickBreak(xx, 0, false));
        }

        for (int yy = 0; yy < 7; yy++)
        {
            for (int xx = 0; xx < 6; xx++)
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
            if (chk) StartCoroutine(BrickBreak(yy, 0, true));
        }

    }

    IEnumerator BrickBreak(int line, int num, bool isHorizontal)
    {
        if (num >= 7)
        {
            isBreaking = false;
            if (firstPlay) firstPlay = false;

            yield break;
        }

        yield return new WaitForSeconds(0.05f);


        isBreaking = true;

        if (isHorizontal)
        {
            StartCoroutine(BrickBreak(line, num + 1, isHorizontal));
            if (Square[num, line].CompareTag("Brick1"))

                Instantiate(orangeEffect, new Vector3(0.75f * num - 2.25f, -0.75f * line + 1.5f, 0), Quaternion.identity);
            else
                Instantiate(blueEffect, new Vector3(0.75f * num - 2.25f, -0.75f * line + 1.5f, 0), Quaternion.identity);

            Destroy(Square[num, line]);
        }
        else
        {
            StartCoroutine(BrickBreak(line, num + 1, isHorizontal));
            if (Square[line, num].CompareTag("Brick1"))
                Instantiate(orangeEffect, new Vector3(0.75f * line - 2.25f, -0.75f * num + 1.5f, 0), Quaternion.identity);
            else
                Instantiate(blueEffect, new Vector3(0.75f * line - 2.25f, -0.75f * num + 1.5f, 0), Quaternion.identity);

            Destroy(Square[line, num]);

        }
        if (isSFX) SoundMgr.instance.BreakSoundPlay();
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

        firstPlayObj.SetActive(false);
        orangeTuto.SetActive(false);


        if (firstBlue)
            blueTuto.SetActive(false);

    }


    void FirstSpawn()
    {
        int ran;
        for (int ii = 0; ii < 7; ii++)
        {
            ran = Random.Range(0, 7);
            Square[ii, ran] = Instantiate(n[1], new Vector3(0.75f * ii - 2.25f, -0.75f * ran + 1.5f, 0), Quaternion.identity);
        }
    }

    void Spawn()
    {
        while (true && !isGameover)
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
                    if (Square[ii, jj] != null)
                    {
                        cnttt++;
                    }
                }
            }
            if (cnttt >= 48)
            {
                TestingAdmob.instance.ShowInterstitial();
                gameover.SetActive(true);
                isGameover = true;
                SoundMgr.instance.OverSoundPlay();
            }
        }

        ra = Random.Range(0, 10);

        if (ra > 0) ra = 1;

        if (Square[x, y] == null)
        {
            Square[x, y] = Instantiate(n[ra], new Vector3(0.74f * x - 2.22f, -0.74f * y + 1.48f, 0), Quaternion.identity);
            if (ra == 0 && firstBlue)
            {
                blueTuto.SetActive(true);
                firstBlue = false;
            }
        }
    }


}
