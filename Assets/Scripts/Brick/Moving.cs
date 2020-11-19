using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    bool move;
    int _x2, _y2;

    private void Start()
    {
<<<<<<< HEAD
        Time.timeScale = 1;
    }

    void Update()
    {
        

        if(transform.localScale.x<0.67f)transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(0.67f, 0.67f, 1), 15 * Time.deltaTime);

        Debug.Log("AS");

        if (move) Move(_x2, _y2);

    }

=======
    }
>>>>>>> 9a674db51d16aee01635b4f3faf8ff5a9324c7b6

    void Update()
    {
<<<<<<< HEAD
        move = true; _x2 = x2; _y2 = y2;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(0.75f * x2 - 2.25f, -0.75f * y2 + 1.5f, 0), 20 * Time.deltaTime);
        if (transform.position == new Vector3(0.75f * x2 - 2.25f, -0.75f * y2 + 1.5f, 0))
=======

        transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(0.65f, 0.65f, 1), 0.3f);

        if (move) Move(_x2, _y2);


    }


    public void Move(int x2, int y2)
>>>>>>> 9a674db51d16aee01635b4f3faf8ff5a9324c7b6
        {
            move = true; _x2 = x2; _y2 = y2;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0.75f * x2 - 2.25f, -0.75f * y2 + 1.5f, 0), 0.1f);
            if (transform.position == new Vector3(0.75f * x2 - 2.25f, -0.75f * y2 + 1.5f, 0))
            {
                move = false;
            }
        }
    }