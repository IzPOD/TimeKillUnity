using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {
    
    public int damage = 1;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public int GetDamage() {
        return damage;
    }

    public void Hit() {
        Destroy(gameObject);
        WinOrLoseScript winOrLoseScript = GameObject.Find("WinOrLose").GetComponent<WinOrLoseScript>();
        winOrLoseScript.CheckWinOrLose();
    }
}
