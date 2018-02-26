using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private int PlayerPositionOnLane = 1;
    

    public int numberOfBullets = 8;

    List<GameObject> bulletsMasLeft = new List<GameObject>();
    List<GameObject> bulletsMasMiddle = new List<GameObject>();
    List<GameObject> bulletsMasRight = new List<GameObject>();

    public GameObject bullet;
    public GameObject TimeCircl;
    // Use this for initialization
    void Start () {
        InvokeRepeating("SpawnBullet", 1, 1);
        TimeCircl = Instantiate(TimeCircl);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            PlayerPositionOnLane--;
            if (PlayerPositionOnLane < 0) {
                PlayerPositionOnLane = 0;
            }
            PlayerPosition();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            PlayerPositionOnLane++;
            if (PlayerPositionOnLane > 2) {
                PlayerPositionOnLane = 2;
            }
            PlayerPosition();
        }

        
     }

    void PlayerPosition() {
        switch (PlayerPositionOnLane) {
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

    void SpawnBullet() {

        switch (PlayerPositionOnLane) {
            case 0:
                bulletsMasLeft.Add(Instantiate(bullet));
                Debug.Log("Лево: "+bulletsMasLeft.Count);
                BulletPosition(bulletsMasLeft, PlayerPositionOnLane);
                break;
            case 1:
                bulletsMasMiddle.Add(Instantiate(bullet));
                Debug.Log("Центр: " + bulletsMasMiddle.Count);
                BulletPosition(bulletsMasMiddle, PlayerPositionOnLane);
                break;
            case 2:
                bulletsMasRight.Add(Instantiate(bullet));
                Debug.Log("Право: " + bulletsMasRight.Count);
                BulletPosition(bulletsMasRight, PlayerPositionOnLane);
                break;
        }



        numberOfBullets--;
        if (numberOfBullets == 0) {
            CancelInvoke("SpawnBullet");
            Destroy(TimeCircl);

        }


    }

    void BulletPosition(List<GameObject> laneList, int numberLane) {
        switch (laneList.Count) {
            case 1:
                laneList[0].GetComponent<Transform>().position = new Vector3(numberLane+0.5f, 1.1f, 0);
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

}
