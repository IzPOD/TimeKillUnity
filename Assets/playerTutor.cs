using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTutor : MonoBehaviour
{

    public Swipe swipeContrals;
    public GameObject TimeCircl;


    public int PlayerPositionOnLane = 1;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
        TimeCircl = Instantiate(TimeCircl);
    }

}
