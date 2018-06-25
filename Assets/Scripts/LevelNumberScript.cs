using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelNumberScript : MonoBehaviour {

    public Text text;
    private string number;

	// Use this for initialization
	void Start () {
        number=SceneManager.GetActiveScene().name;
        text.text = "уровень: "+ number[5]+ "\nНажми по готовности";
    }

    // Update is called once per frame
    void Update () {
		
	}
}
