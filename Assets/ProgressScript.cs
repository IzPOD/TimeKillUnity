using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ProgressScript : MonoBehaviour
{

    static public int progress = -1;
    //GameObject[] lvlButtons;

    // Use this for initialization
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "StartScene")
        {
            for (int i = 0; i <= progress + 1; i++)
            {
                SnapScrolling.lvlButtons[i].GetComponent<Button>().enabled = true;
                SnapScrolling.lvlButtons[i].GetComponent<Image>().color = new Color(255,255,255,255);

            }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
