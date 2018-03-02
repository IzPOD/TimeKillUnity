using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sredder : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D col) {
        //Destroy(col.gameObject);
        BulletScript bullet = col.gameObject.GetComponent<BulletScript>();
        bullet.Hit();
    }
}
