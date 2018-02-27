using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinOrLoseScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void CheckWinOrLose() {
        if (GameObject.Find("Bullet(Clone)")) {
            Debug.Log("Hqwe");
        }
        else {
            Debug.Log("Hqwqweqweqwee");
        }

    }
}
