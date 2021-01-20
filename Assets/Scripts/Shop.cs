using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    int money;

    public GameObject[] locked;

    


    // Start is called before the first frame update
    void Start()
    {
        locked = new GameObject[7];
        money = PlayerPrefs.GetInt("money");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
