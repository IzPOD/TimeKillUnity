using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour {
    public int targetHealth = 2;
    

    // Use this for initialization
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        BulletScript bullet = collision.gameObject.GetComponent<BulletScript>();
        targetHealth -= bullet.GetDamage();
        if (targetHealth <= 0) {
            Destroy(gameObject);
        }
        bullet.Hit();

    }
}
