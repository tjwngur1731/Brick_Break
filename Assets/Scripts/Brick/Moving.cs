﻿using UnityEngine;

public class Moving : MonoBehaviour
{
    bool move;
    int _x2, _y2;

    void Update() { if (move) Move(_x2, _y2); }

    public void Move(int x2, int y2)
    {
        move = true; _x2 = x2; _y2 = y2;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(0.75f * x2 - 2.25f, -0.75f * y2 + 1.5f, 0), 0.07f);
        if (transform.position == new Vector3(0.75f * x2 - 2.25f, -0.75f * y2 + 1.5f, 0))
        {
            move = false;
        }
    }
}