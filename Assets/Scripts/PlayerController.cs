using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject bullet;
    public GameObject TimeCircl;
    public GameObject Countdown;
    public float projectileSpeed = 2f;
    public int numberOfBullets = 8;
    public Swipe swipeContrals;
    public GameObject readyText;

    List<GameObject> bulletsMasLeft = new List<GameObject>();
    List<GameObject> bulletsMasMiddle = new List<GameObject>();
    List<GameObject> bulletsMasRight = new List<GameObject>();
    List<GameObject> allBullets = new List<GameObject>();

    private bool playerReady = false;
    private bool shootCheck = false;
    private int PlayerPositionOnLane = 1;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (swipeContrals.Tap && playerReady==false)
        {
            playerReady = true;
            StartLevel();
            Destroy(readyText);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            PlayerPositionOnLane--;
            if (PlayerPositionOnLane < 0)
            {
                PlayerPositionOnLane = 0;
            }
            PlayerPosition();
        }

        if (swipeContrals.SwipeLeft)
        {
            PlayerPositionOnLane--;
            if (PlayerPositionOnLane < 0)
            {
                PlayerPositionOnLane = 0;
            }
            PlayerPosition();
        }

        if (swipeContrals.SwipeRight)
        {
            PlayerPositionOnLane++;
            if (PlayerPositionOnLane > 2)
            {
                PlayerPositionOnLane = 2;
            }
            PlayerPosition();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            PlayerPositionOnLane++;
            if (PlayerPositionOnLane > 2)
            {
                PlayerPositionOnLane = 2;
            }
            PlayerPosition();
        }

        if (shootCheck)
        {
            ShootBullets();
        }


    }

    void StartLevel()
    {
        InvokeRepeating("SpawnBullet", 3, 1);
        TimeCircl = Instantiate(TimeCircl);
        Countdown = Instantiate(Countdown);
    }

    void PlayerPosition()
    {
        switch (PlayerPositionOnLane)
        {
            case 0:
                transform.position = new Vector3(0.5f, 0.5f);
                break;
            case 1:
                transform.position = new Vector3(1.5f, 0.5f);
                break;
            case 2:
                transform.position = new Vector3(2.5f, 0.5f);
                break;
        }
    }

    void SpawnBullet()
    {
        Destroy(Countdown);
        switch (PlayerPositionOnLane)
        {
            case 0:
                bulletsMasLeft.Add(Instantiate(bullet));
                BulletPosition(bulletsMasLeft, PlayerPositionOnLane);
                allBullets.Add(bulletsMasLeft[bulletsMasLeft.Count - 1]);
                break;
            case 1:
                bulletsMasMiddle.Add(Instantiate(bullet));
                BulletPosition(bulletsMasMiddle, PlayerPositionOnLane);
                allBullets.Add(bulletsMasMiddle[bulletsMasMiddle.Count - 1]);
                break;
            case 2:
                bulletsMasRight.Add(Instantiate(bullet));
                BulletPosition(bulletsMasRight, PlayerPositionOnLane);
                allBullets.Add(bulletsMasRight[bulletsMasRight.Count - 1]);
                break;
        }

        numberOfBullets--;
        if (numberOfBullets == 0)
        {
            CancelInvoke("SpawnBullet");
            Destroy(TimeCircl);
            shootCheck = true;
        }


    }

    void BulletPosition(List<GameObject> laneList, int numberLane)
    {
        switch (laneList.Count)
        {
            case 1:
                laneList[0].GetComponent<Transform>().position = new Vector3(numberLane + 0.5f, 1.1f, 0);
                break;
            case 2:
                laneList[0].GetComponent<Transform>().position = new Vector3(numberLane + 0.45f, 1.1f, 0);
                laneList[1].GetComponent<Transform>().position = new Vector3(numberLane + 0.55f, 1.1f, 0);
                break;
            case 3:
                laneList[0].GetComponent<Transform>().position = new Vector3(numberLane + 0.4f, 1.1f, 0);
                laneList[1].GetComponent<Transform>().position = new Vector3(numberLane + 0.5f, 1.1f, 0);
                laneList[2].GetComponent<Transform>().position = new Vector3(numberLane + 0.6f, 1.1f, 0);
                break;
            case 4:
                laneList[0].GetComponent<Transform>().position = new Vector3(numberLane + 0.35f, 1.1f, 0);
                laneList[1].GetComponent<Transform>().position = new Vector3(numberLane + 0.45f, 1.1f, 0);
                laneList[2].GetComponent<Transform>().position = new Vector3(numberLane + 0.55f, 1.1f, 0);
                laneList[3].GetComponent<Transform>().position = new Vector3(numberLane + 0.65f, 1.1f, 0);
                break;
            case 5:
                laneList[4].GetComponent<Transform>().position = new Vector3(numberLane + 0.5f, 1.2f, 0);
                break;
            case 6:
                laneList[4].GetComponent<Transform>().position = new Vector3(numberLane + 0.45f, 1.2f, 0);
                laneList[5].GetComponent<Transform>().position = new Vector3(numberLane + 0.55f, 1.2f, 0);
                break;
            case 7:
                laneList[4].GetComponent<Transform>().position = new Vector3(numberLane + 0.4f, 1.2f, 0);
                laneList[5].GetComponent<Transform>().position = new Vector3(numberLane + 0.5f, 1.2f, 0);
                laneList[6].GetComponent<Transform>().position = new Vector3(numberLane + 0.6f, 1.2f, 0);
                break;
            case 8:
                laneList[4].GetComponent<Transform>().position = new Vector3(numberLane + 0.35f, 1.2f, 0);
                laneList[5].GetComponent<Transform>().position = new Vector3(numberLane + 0.45f, 1.2f, 0);
                laneList[6].GetComponent<Transform>().position = new Vector3(numberLane + 0.55f, 1.2f, 0);
                laneList[7].GetComponent<Transform>().position = new Vector3(numberLane + 0.65f, 1.2f, 0);
                break;
        }


    }

    void ShootBullets()
    {

        if (allBullets[numberOfBullets] == null)
        {
            numberOfBullets++;
        }
        else
        {
            allBullets[numberOfBullets].GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed, 0);
        }

        if (numberOfBullets == allBullets.Count)
        {
            shootCheck = false;
        }



    }

}
