﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {


    private float secondsAll;

    public void LoadLevel(string name) {
        Debug.Log("Level: " + name);
        SceneManager.LoadScene(name);
    }

    public void getSeconds(float seconds) {
        secondsAll = seconds;
    }

    public void LoadLevelWithTime(string name) {

        StartCoroutine(processTask(name));
    }

    IEnumerator processTask(string name) {
        yield return new WaitForSeconds(secondsAll);
        Debug.Log("Level: " + name);
        SceneManager.LoadScene(name);
    }



}
