using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour
{
    public GameObject[] n;

    int x, y, i;
    int curScore, highScore;
    int checkCntX, checkCntY;

    GameObject[,] Square;
    // Start is called before the first frame update
    void Start()
    {
        Square = new GameObject[7, 7];
        highScore = PlayerPrefs.GetInt("highScore");
        Spawn();
        Spawn();
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // 일시정지
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            for (x = 0; x <= 6; x++)
                for (y = 0; y <= 5; y++)
                    for (i = 6; i >= y + 1; i--)
                        BrickMove(x, i - 1, x, i);
            BrickCheck();
            Spawn();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            for (x = 0; x <= 6; x++)
                for (y = 6; y >= 1; y--)
                    for (i = 0; i <= y - 1; i++)
                        BrickMove(x, i + 1, x, i);
            BrickCheck();
            Spawn();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            for (y = 0; y <= 6; y++)
                for (x = 0; x <= 5; x++)
                    for (i = 6; i >= x + 1; i--)
                        BrickMove(i - 1, y, i, y);
            BrickCheck();
            Spawn();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            for (y = 0; y <= 6; y++)
                for (x = 6; x >= 1; x--)
                    for (i = 0; i <= x - 1; i++)
                        BrickMove(i + 1, y, i, y);
            BrickCheck();
            Spawn();
        }

    }

    void BrickCheck()
    {
        checkCntX = 0;
        checkCntY = 0;
        int x1, y1;
        for (x1 = 0; x1 < 7; x1++)
        {
            for (y1 = 0; y1 < 6; y1++)
            {
                if (Square[x1, y1] != null && Square[x1, y1 + 1] != null)
                {
                    if (Square[x1, y1].CompareTag(Square[x1, y1 + 1].tag))
                    {
                        checkCntY++;
                    }
                }
                if (checkCntY == 6)
                    BrickBreak(x1, true);
            }
            checkCntY = 0;
        }
        for (y1 = 0; y1 < 7; y1++)
        {
            for (x1 = 0; x1 < 6; x1++)
            {
                if (Square[x1, y1] != null && Square[x1 + 1, y1] != null)
                {
                    if (Square[x1, y1].CompareTag(Square[x1 + 1, y1].tag))
                    {
                        checkCntX++;
                    }
                }
                if(checkCntX==6)
                    BrickBreak(y1, true);
            }
            checkCntX = 0;
        }
    }

    void BrickBreak(int line,bool isHorizontal)
    {
        
        if (isHorizontal)
        {
            for(int ii=0;ii<7;ii++)
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
            x = Random.Range(0, 7);
            y = Random.Range(0, 7);

            if (Square[x, y] == null)
                break;
        }

        if (Square[x, y] == null)
        {
            Square[x, y] = Instantiate(n[Random.Range(0, 2)], new Vector3(0.8f * x - 2.4f, 0.8f * y - 2.4f, 0), Quaternion.identity);
        }
    }
}
