using UnityEngine;

public class Moving : MonoBehaviour
{
    bool move;
    int _x2, _y2;

    void Update() { if (move) Move(_x2, _y2); }

    public void Move(int x2, int y2)
    {
        move = true; _x2 = x2; _y2 = y2;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(0.8f * x2 - 2.4f, 0.8f * y2 - 2.4f, 0), 0.2f);
        if (transform.position == new Vector3(0.8f * x2 - 2.4f, 0.8f * y2 - 2.4f, 0))
        {
            move = false;
        }
    }
}