using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour
{
    public GameObject[] brickPrefab;

    public int[,] map;

    public static BrickManager instance = null;

    void Awake()
    {
        if (!instance) instance = this;
    }

    void Start()
    {
        map = new int[7, 7];
        for(int i=0;i<7;i++)
        {
            for(int j=0;j<7;j++)
            {
            }
        }
        BrickSpawn();
    }
    void Update()
    {
        BrickCheck();
    }

    void BrickSpawn()
    {
        int[] spawnPos;
        spawnPos = new int[2];
        int brick = Random.Range(1,3);

        for (int i = 0; i < 2; i++)
        {
            spawnPos[i] = Random.Range(0, 7);
        }
        if (map[spawnPos[0], spawnPos[1]] == 0)
        {
            Instantiate(brickPrefab[brick-1], Vector3.zero, Quaternion.Euler(0, 0, 0));
            map[spawnPos[0], spawnPos[1]] = brick;
        }
    }

    void BrickCheck()
    {
        int brickCnt;
        for(int i=0;i<6;i++)
        {
            brickCnt = 0;
            for(int j=0;j<6;j++)
            {
                if(map[i,j] == map[i+1,j+1])
                {
                    brickCnt++;
                }
                
                if(brickCnt == 6)
                {
                    for(int h=0;h<7;h++)
                    {
                        map[i, j] = 0;
                    }
                }
            }
        }
    }
}
