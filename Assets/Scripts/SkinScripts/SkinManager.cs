using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinManager : MonoBehaviour
{
    public GameObject background;
    public GameObject block;

    Image image;
    Image blockImg;

    public Sprite[] sprite;
    public Sprite[] blockSprite;

    int skinNum;

    private Vector3 fp;
    private Vector3 lp;
    private float dragDistance;

    public static SkinManager instance = null; 

    void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);



        background = GameObject.FindGameObjectWithTag("Background");
        block = GameObject.Find("Block");
        image = background.GetComponent<Image>();
        if (block != null)
            blockImg = block.GetComponent<Image>();

        skinNum = PlayerPrefs.GetInt("SkinNum");

    }

    void Start()
    {
        dragDistance = Screen.height * 7 / 100;

        image.sprite = sprite[skinNum];

        blockImg.sprite = blockSprite[skinNum];
    }

    private void Update()
    {
        if (Input.touchCount == 1) // user is touching the screen with a single touch
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
                        if ((lp.x > fp.x))  //If the movement was to the right)
                        {   //Right swipe
                            skinNum--;
                            if (skinNum < 0)
                            {
                                skinNum++;
                            }
                        }
                        else
                        {   //Left swipe
                        skinNum++;
                        if (skinNum > 6)
                        {
                            skinNum--;
                        }
                    }
                        SkinChange(skinNum);
                }
                else
                {   //It's a tap as the drag distance is less than 20% of the screen height
                    Debug.Log("Tap");
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            skinNum++;
            if (skinNum > 6)
            {
                skinNum--;
            }
            SkinChange(skinNum);

            Debug.Log(skinNum);
        }

        else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            skinNum--;
            if (skinNum < 0)
            {
                skinNum++;
            }

            SkinChange(skinNum);

            Debug.Log(skinNum);

        }
    }

    public void SkinChange(int skin)
    {
        image.sprite = sprite[skin];
        blockImg.sprite = blockSprite[skin];

        Debug.Log(skin);
        PlayerPrefs.SetInt("SkinNum", skin);
        //SoundMgr.instance.TouchSoundPlay();
    }
}
