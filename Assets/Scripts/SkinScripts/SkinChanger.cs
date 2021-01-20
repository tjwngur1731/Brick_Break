using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinChanger : MonoBehaviour
{
    public Sprite[] sp;

    Image img;

    private void Start()
    {
        img = GetComponent<Image>();
    }
    // Update is called once per frame
    void Update()
    {
        img.sprite = sp[PlayerPrefs.GetInt("SkinNum")];
    }
}
