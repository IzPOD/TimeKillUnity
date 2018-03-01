using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTargets : MonoBehaviour {

    public GameObject targetPrefab;
    
    // Use this for initialization
    void Start () {
        foreach (Transform child in transform) {
            GameObject target = Instantiate(targetPrefab, child.transform.position, Quaternion.identity) as GameObject;
            target.transform.parent = child;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
