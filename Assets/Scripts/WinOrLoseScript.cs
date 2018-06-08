using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinOrLoseScript : MonoBehaviour {

    bool check = false;
    public GameObject LoseEndLvLMenuCanvas;
    public GameObject WinEndLvLMenuCanvas;
    public string NextLvLName;
    GameObject LevelManager;
    // Use this for initialization
    void Start() {
        LevelManager = GameObject.Find("LevelManager");
    }

    // Update is called once per frame
    void Update() {
        if (check) {
            if (!GameObject.Find("Bullet(Clone)")) {

                if (!GameObject.Find("Target(Clone)")) {
                    Debug.Log("ti win");
                    //WinEndLvLMenuCanvas = Instantiate(WinEndLvLMenuCanvas);
                    //WinEndLvLMenuCanvas.transform.Find("NextLvLText").GetComponent<Button>().onClick.AddListener(delegate { LevelManager.GetComponent<LevelManager>().LoadLevel(NextLvLName); });
                    LevelManager.GetComponent<LevelManager>().LoadLevel(NextLvLName);
                }
                else {
                    Debug.Log("ti lose");
                    //LoseEndLvLMenuCanvas = Instantiate(LoseEndLvLMenuCanvas);
                    //LoseEndLvLMenuCanvas.transform.Find("Retry").GetComponent<Button>().onClick.AddListener(delegate { LevelManager.GetComponent<LevelManager>().RestartLevel(); });
                    LevelManager.GetComponent<LevelManager>().RestartLevel();
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
