using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountBulletsOnScene : MonoBehaviour {
    
    static int number;

    // Use this for initialization
    void Start () {
        number = PlayerController.numberOfBullets;
        this.GetComponent<Text>().text = ("x" + number);

    }

    public static void SetNumberText()
    {
        number = PlayerController.numberOfBullets;
    }

    void Update()
    {
        this.GetComponent<Text>().text = ("x" + number);
    }

}
