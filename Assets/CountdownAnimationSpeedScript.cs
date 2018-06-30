using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownAnimationSpeedScript : MonoBehaviour {

    public static float animSpeed;

    Animator anim;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        anim.SetFloat("Speed", animSpeed);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
