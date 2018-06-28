using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    
    private float secondsAll;

    public void LoadLevel(string name) {
        SceneManager.LoadScene(name);
        Debug.Log("Level: " + name);
    }

    public void ChangeFlag()
    {
        string fullName = SceneManager.GetActiveScene().name;
        string oneLetter = fullName.Remove(0, 5);
        int number = int.Parse(oneLetter);
        SnapScrolling.flagLvlsPosition = number;
        
    }

    public void RestartLevel() {
        Debug.Log("Restart Lvl");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void getSeconds(float seconds) {
        secondsAll = seconds;
    }

    public void LoadLevelWithTime(string name) {

        StartCoroutine(processTask(name));
    }

    IEnumerator processTask(string name) {
        yield return new WaitForSeconds(secondsAll);
        Debug.Log("Level: " + name);
        SceneManager.LoadScene(name);
    }



}
