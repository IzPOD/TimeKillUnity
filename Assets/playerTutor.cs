using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTutor : MonoBehaviour
{

    public Swipe swipeContrals;
    public GameObject TimeCircl;
    public GameObject bullet;
    public int PlayerPositionOnLane = 1;

    private int bulletInt = 0;
    private bool shootCheck = false;
    List<GameObject> bulletsMasMiddle = new List<GameObject>();
    private GameObject timeCircl;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (shootCheck)
        {
            ShootBullets();
        }
    }

    public void PlayerPosition()
    {
        switch (PlayerPositionOnLane)
        {
            case 0:
                transform.position = new Vector3(0.5f, 0.5f);
                break;
            case 1:
                transform.position = new Vector3(1.5f, 0.5f);
                break;
        }
    }

    public void InstantiateTimeCiecl()
    {
        if (timeCircl == null)
            timeCircl = Instantiate(TimeCircl);
        else
        {
            Destroy(timeCircl);
            timeCircl = Instantiate(TimeCircl);

        }
    }

    public void SpawnBulletsTutor()
    {
        InvokeRepeating("SpawnBullet", 1, 1);
    }

    void SpawnBullet()
    {
        switch (PlayerPositionOnLane)
        {
            case 1:
                bulletsMasMiddle.Add(Instantiate(bullet));
                BulletPosition(bulletsMasMiddle, PlayerPositionOnLane);
                break;
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
                for (int i = 0; i < bulletsMasMiddle.Count; i++)
                {
                    Destroy(bulletsMasMiddle[i]);
                }
                bulletsMasMiddle.Clear();

                break;
        }
    }

    public void SpawnAndShootForTutor()
    {
        Destroy(GameObject.Find("Metronome(Clone)"));
        CancelInvoke("SpawnBullet");
        if (bulletsMasMiddle != null)
        {
            for (int i = 0; i < bulletsMasMiddle.Count; i++)
            {
                Destroy(bulletsMasMiddle[i]);
            }
        }
        bulletsMasMiddle.Clear();
        for (int i = 0; i < 3; i++)
        {
            bulletsMasMiddle.Add(Instantiate(bullet));
            bulletsMasMiddle[i].GetComponent<Transform>().position = new Vector3(i + 0.5f, 1.1f, 0);
        }
        shootCheck = true;
    }

    void ShootBullets()
    {


        if (bulletsMasMiddle[bulletInt] == null)
        {
            bulletInt++;
        }
        bulletsMasMiddle[bulletInt].GetComponent<Rigidbody2D>().velocity = new Vector3(0, 15, 0);
        
        if (bulletInt == 2)
        {
            shootCheck = false;

        }
        

    }
}

