using UnityEngine;

public class Moving : MonoBehaviour
{
    bool move;
    int _x2, _y2;

    void Update() { if (move) Move(_x2, _y2); }

    public void Move(int x2, int y2)
    {
        move = true; _x2 = x2; _y2 = y2;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(0.81f * x2 - 2.43f, 0.81f * y2 - 2.43f - 0.7f, 0), 0.17f);
        if (transform.position == new Vector3(0.81f * x2 - 2.43f, 0.81f * y2 - 2.43f - 0.7f, 0))
        {
            move = false;
        }
    }
}