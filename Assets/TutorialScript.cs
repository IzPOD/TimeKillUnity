using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour
{

    public GameObject mask;
    public GameObject darkLayer;
    public Text text;
    public Swipe swipeContrals;
    public GameObject Player;
    public GameObject targets;


    private GameObject mask2;
    private int tutorCase = 0;
    private bool getTap = false;
    private bool getSwipeLeft = false;
    private bool getSwipeRight = false;

    // Use this for initialization
    void Start()
    {
        TutorNextStep();
    }

    // Update is called once per frame
    void Update()
    {
        if (swipeContrals.Tap && getTap)
           
            {
                tutorCase++;
            Debug.Log(tutorCase);

            getTap = false;
            TutorNextStep();

        }

        if (swipeContrals.SwipeLeft && getSwipeLeft)

            {
                tutorCase++;
            Debug.Log(tutorCase);
            getSwipeLeft = false;
            TutorNextStep();

        }

        if (swipeContrals.SwipeRight && getSwipeRight)
           

            {
                tutorCase++;
            Debug.Log(tutorCase);
            getSwipeRight = false;
            TutorNextStep();


        }
    }

    void TutorNextStep()
    {
        switch (tutorCase)
        {
            case 0:
                text.text = "давай покажу что надо делать";
                getTap = true;
                break;
            case 1:
                text.text = "ты управляешь треугольником";
                mask.SetActive(true);
                Player.SetActive(true);
                getTap = true;
                break;
            case 2:
                text.text = "проведи по экрану влево";
                text.GetComponent<Text>().transform.position = new Vector3(1.5f, 1.4f, 0);
                getSwipeLeft = true;
                break;
            case 3:
                Player.GetComponent<playerTutor>().PlayerPositionOnLane--;
                Player.GetComponent<playerTutor>().PlayerPosition();
                text.text = "проведи по экрану вправо";
                getSwipeRight = true;
                break;
            case 4:
                Player.GetComponent<playerTutor>().PlayerPositionOnLane++;
                Player.GetComponent<playerTutor>().PlayerPosition();
                text.text = "это метроном";
                Player.GetComponent<playerTutor>().InstantiateTimeCiecl();
                mask.GetComponent<Transform>().position = new Vector3(1.5f, 2.65f);
                mask.GetComponent<Transform>().localScale = new Vector3(0.33f, 1f);
                text.GetComponent<Text>().transform.position = new Vector3(1.5f, 3.3f, 0);
                getTap = true;
                break;
            case 5:
                text.text = "под его ритм треугольник создает пули";
                text.GetComponent<Text>().transform.position = new Vector3(1.5f, 1.7f, 0);
                mask2 = Instantiate(mask);
                mask2.transform.position = new Vector3(1.5f, 1.1f, 0);
                mask2.transform.localScale = new Vector3(1f, 0.15f, 0);
                mask2.transform.parent = GameObject.Find("tutorial").transform;
                Player.GetComponent<playerTutor>().InstantiateTimeCiecl();
                Player.GetComponent<playerTutor>().SpawnBulletsTutor();
                getTap = true;
                break;
            case 6:
                text.text = "истреби все мишени!";
                Destroy(mask2);
                targets.SetActive(true);
                mask.transform.position = new Vector3(1.5f, 4.84f, 0);
                mask.transform.localScale = new Vector3(1, 1, 1);
                text.GetComponent<Text>().transform.position = new Vector3(1.5f, 4.1f, 0);
                getTap = true;
                break;
            case 7:

                Player.GetComponent<playerTutor>().SpawnAndShootForTutor();
                darkLayer.SetActive(false);
                text.text = "";

                
                break;
        }
    }



}
