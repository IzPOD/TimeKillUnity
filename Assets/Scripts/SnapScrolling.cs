using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnapScrolling : MonoBehaviour
{
    //https://youtu.be/njfc_QYKdio
    public ScrollRect myScrollRect;
    [Range(0f, 20f)]
    public float snapSpeed;
    [Range(0f, 5f)]
    public float scaleOffset;
    [Range(0, 500)]
    public int buttinOffset;
    [Range(1f, 20f)]
    public float scaleSpeed;
    [Range(1, 10)]
    public int scrollSpeed;
    public Sprite[] lvlsSprites;
    public GameObject lvlsPrefab;
    public GameObject levelManager;

    private GameObject[] lvlButtons;
    private Vector2[] buttonPos;
    private RectTransform contentRect;
    private int selectedButtonID;
    private bool isScrolling;
    private bool isClicking;
    private Vector2 contentVector;
    private Vector2[] buttonScale;
    private float rangeBetweenButtons = 600;
    // Use this for initialization

    void Start()
    {
        SpawnLvlsButtons();
        buttonScale = new Vector2[lvlButtons.Length];
        contentRect = GetComponent<RectTransform>();
        buttonPos = new Vector2[lvlButtons.Length];
        for (int i = 0; i < lvlButtons.Length; i++)
        {
            //Instantiate(lvlButtons[i],new Vector2(0,0),RectTransform);
            buttonPos[i] = -lvlButtons[i].transform.localPosition;
        }
        myScrollRect.scrollFactor = scrollSpeed;//https://forum.unity.com/threads/make-scrolling-move-faster-in-scrollrect.375116/

        //contentRect.anchoredPosition = new Vector2(0f, 3005.036f);
        //lvlButtons[5].transform.localScale = new Vector2 (1f,1f);    

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float nearestPos = float.MaxValue;
        for (int i = 0; i < lvlButtons.Length; i++)
        {
            float distance = Mathf.Abs(contentRect.anchoredPosition.y - buttonPos[i].y);
            if (distance < nearestPos)
            {
                nearestPos = distance;
                selectedButtonID = i;
            }
            float scale = Mathf.Clamp(1 / (distance / buttinOffset) * scaleOffset, 0.5f, 1f);
            buttonScale[i].x = Mathf.SmoothStep(lvlButtons[i].transform.localScale.x, scale, scaleSpeed * Time.fixedDeltaTime);
            buttonScale[i].y = Mathf.SmoothStep(lvlButtons[i].transform.localScale.y, scale, scaleSpeed * Time.fixedDeltaTime);
            lvlButtons[i].transform.localScale = buttonScale[i];

        }
        if (isScrolling) return;

        contentVector.y = Mathf.SmoothStep(contentRect.anchoredPosition.y, buttonPos[selectedButtonID].y - 39.97525f, snapSpeed * Time.fixedDeltaTime);
        contentRect.anchoredPosition = contentVector;
        if (!isClicking) return;
        buttonScale[selectedButtonID].x = Mathf.SmoothStep(lvlButtons[selectedButtonID].transform.localScale.x, lvlButtons[selectedButtonID].transform.localScale.x - 1f, 10 * Time.fixedDeltaTime);
        buttonScale[selectedButtonID].y = Mathf.SmoothStep(lvlButtons[selectedButtonID].transform.localScale.y, lvlButtons[selectedButtonID].transform.localScale.y - 1f, 10 * Time.fixedDeltaTime);
        lvlButtons[selectedButtonID].transform.localScale = buttonScale[selectedButtonID];

    }

    public void Scrolling(bool scroll)
    {
        isScrolling = scroll;
    }

    public void ScaleWhenClick(bool click)
    {
        isClicking = click;

    }

    void SpawnLvlsButtons()
    {
        lvlButtons = new GameObject[lvlsSprites.Length];
        float position = lvlsPrefab.transform.localPosition.y + rangeBetweenButtons;

        for (int i = 0; i < lvlsSprites.Length; i++)
        {
            lvlButtons[i] = Instantiate(lvlsPrefab, transform);
            lvlButtons[i].GetComponent<Image>().sprite = lvlsSprites[i];
            lvlButtons[i].transform.localPosition = new Vector2(0, position -= rangeBetweenButtons);
        }
        //lvlButtons[0].GetComponent<Button>().onClick.AddListener(delegate { GetComponent<LevelManager>().getSeconds(0.2f); });
        //lvlButtons[0].GetComponent<Button>().onClick.AddListener(delegate { GetComponent<LevelManager>().LoadLevel("TutorialScene"); });
       
        //lvlButtons[0].GetComponent<Button>().onClick.AddListener(delegate { GameObject.Find("LevelManager").GetComponent<LevelManager>().getSeconds(0.2f); });
        //lvlButtons[0].GetComponent<Button>().onClick.AddListener(delegate { GameObject.Find("LevelManager").GetComponent<LevelManager>().LoadLevel("TutorialScene"); });
    }

    //void TaskOnClick()
    //{
    //    GameObject.Find("LevelManager").GetComponent<LevelManager>().LoadLevel("TutorialScene");
    //}

}
