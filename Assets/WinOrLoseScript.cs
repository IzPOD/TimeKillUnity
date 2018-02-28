using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinOrLoseScript : MonoBehaviour {

    SpawnTargets spawnTargets;
    bool check = false;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (check) {
            if (!GameObject.Find("Bullet(Clone)")) {
                

                if (!GameObject.Find("Target(Clone)")) {
                    Debug.Log("ti win");
                }
                else {
                    Debug.Log("ti lose");
                }

                check = false;
            }
        }
    }
    
    public void CheckWinOrLose() {
        check = true;
        
    }
}
