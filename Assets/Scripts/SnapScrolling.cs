using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnapScrolling : MonoBehaviour
{
    //https://youtu.be/njfc_QYKdio
    public ScrollRect myScrollRect;
    public static GameObject[] lvlButtons;
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

    private Vector2[] buttonPos;
    private RectTransform contentRect;
    private int selectedButtonID;
    private bool isScrolling;
    private bool isClicking;
    private Vector2 contentVector;
    private Vector2[] buttonScale;
    static public int flagLvlsPosition;
    // Use this for initialization

    void Start()
    {
        AddAllButtonsOnArray();
        buttonScale = new Vector2[lvlButtons.Length];
        contentRect = GetComponent<RectTransform>();
        buttonPos = new Vector2[lvlButtons.Length];
        for (int i = 0; i < lvlButtons.Length; i++)
        {
            //Instantiate(lvlButtons[i],new Vector2(0,0),RectTransform);
            buttonPos[i] = -lvlButtons[i].transform.localPosition;
        }
        myScrollRect.scrollFactor = scrollSpeed;//https://forum.unity.com/threads/make-scrolling-move-faster-in-scrollrect.375116/
        
        contentRect.anchoredPosition = new Vector2(0f, Mathf.Abs(lvlButtons[flagLvlsPosition].GetComponent<RectTransform>().anchoredPosition.y) - 39.986f);
        lvlButtons[flagLvlsPosition].transform.localScale = new Vector2 (1f,1f);    
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

    void AddAllButtonsOnArray()
    {
        lvlButtons = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            lvlButtons[i] = transform.GetChild(i).gameObject;
        }

    }

}
