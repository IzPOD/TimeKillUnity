using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButtonScript : MonoBehaviour
{
    GameObject LevelManager;
    public bool ifMainScene;

    // Use this for initialization
    void Start()
    {
        LevelManager = GameObject.Find("LevelManager");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (ifMainScene)
                Application.Quit();

            else
                LevelManager.GetComponent<LevelManager>().LoadLevel("StartScene");

        }
    }
}