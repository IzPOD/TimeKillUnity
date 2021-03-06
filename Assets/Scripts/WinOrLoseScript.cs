﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class WinOrLoseScript : MonoBehaviour
{
    public ProgressScript progressScript;
    bool check = false;
    public string NextLvLName;
    GameObject LevelManager;
    // Use this for initialization
    void Start()
    {
        LevelManager = GameObject.Find("LevelManager");
    }

    // Update is called once per frame
    void Update()
    {
        if (check)
        {
            if (!GameObject.Find("Bullet(Clone)"))
            {

                if (!GameObject.FindGameObjectWithTag("Target"))
                {
                    Debug.Log("ti win");
                    //WinEndLvLMenuCanvas = Instantiate(WinEndLvLMenuCanvas);
                    //WinEndLvLMenuCanvas.transform.Find("NextLvLText").GetComponent<Button>().onClick.AddListener(delegate { LevelManager.GetComponent<LevelManager>().LoadLevel(NextLvLName); });
                    int lvlNymber = LvlNumber();
                    if (ProgressScript.progress < lvlNymber)
                    {
                        ProgressScript.progress = lvlNymber;
                        progressScript.SaveFile();
                    }

                    LevelManager.GetComponent<LevelManager>().LoadLevel(NextLvLName);
                }
                else
                {
                    Debug.Log("ti lose");
                    //LoseEndLvLMenuCanvas = Instantiate(LoseEndLvLMenuCanvas);
                    //LoseEndLvLMenuCanvas.transform.Find("Retry").GetComponent<Button>().onClick.AddListener(delegate { LevelManager.GetComponent<LevelManager>().RestartLevel(); });
                    LevelManager.GetComponent<LevelManager>().RestartLevel();
                }

                check = false;
            }
            else
            {
                check = false;
            }
        }
    }

    public void CheckWinOrLose()
    {
        check = true;
    }
    public int LvlNumber()
    {
        int outInt;
        string fullName = SceneManager.GetActiveScene().name;
        string oneLetter = fullName.Remove(0, 5);
        int.TryParse(oneLetter, out outInt);
        return outInt;
    }
    
}