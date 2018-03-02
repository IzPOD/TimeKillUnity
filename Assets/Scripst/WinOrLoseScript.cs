using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinOrLoseScript : MonoBehaviour {

    bool check = false;
    public GameObject LoseEndLvLMenuCanvas;
    public GameObject WinEndLvLMenuCanvas;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (check) {
            if (!GameObject.Find("Bullet(Clone)")) {

                if (!GameObject.Find("Target(Clone)")) {
                    Debug.Log("ti win");
                    WinEndLvLMenuCanvas = Instantiate(WinEndLvLMenuCanvas);
                }
                else {
                    Debug.Log("ti lose");
                    LoseEndLvLMenuCanvas = Instantiate(LoseEndLvLMenuCanvas);

                }

                check = false;
            }
            else {
                check = false;
            }
        }
    }

    public void CheckWinOrLose() {
        check = true;
    }
}
