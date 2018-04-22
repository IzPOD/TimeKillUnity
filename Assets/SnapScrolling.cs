using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapScrolling : MonoBehaviour {

    public GameObject[] lvlButtons;
    [Range(0f, 20f)]
    public float snapSpeed;

    private Vector2[] buttonPos;
    private RectTransform contentRect;
    private int selectedButtonID;
    private bool isScrolling;
    private Vector2 contentVector;

	// Use this for initialization
	void Start () {
        contentRect = GetComponent<RectTransform>();
        buttonPos = new Vector2[2];
        for (int i = 0; i < 2; i++) {
            buttonPos[i] = -lvlButtons[i].transform.localPosition;
        }
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float nearestPos = float.MaxValue;
        for (int i = 0; i < 2; i++) {
            float distance = Mathf.Abs(contentRect.anchoredPosition.y - buttonPos[i].y);
            if (distance < nearestPos) {
                nearestPos = distance;
                selectedButtonID = i;
            }
        }
        if (isScrolling) return;
        contentVector.y = Mathf.SmoothStep(contentRect.anchoredPosition.y, buttonPos[selectedButtonID].y - 39.97525f, snapSpeed * Time.fixedDeltaTime);
        contentRect.anchoredPosition = contentVector;   
	}

    public void Scrolling(bool scroll) {
        isScrolling = scroll;
    }
}
