using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSettingsScript : MonoBehaviour {

    public float projectileSpeed;
    public float projectileSpeedAfter;
    public int numberOfBullets;

    public float gameSpeed;

    // Use this for initialization
    void Start () {
        //MovingObjAnimationScript.animSpeed = metronomeAnimationSpeed;
        //CountdownAnimationSpeedScript.animSpeed = countDownAnimationSpeed;
        //PlayerController.timeBeforeSpawnBullets = timeBeforeSpawnBullets;
        //PlayerController.spawnFrequency = spawnFrequency;
        PlayerController.projectileSpeed = projectileSpeed;
        PlayerController.projectileSpeedAfter = projectileSpeedAfter;
        PlayerController.numberOfBullets = numberOfBullets;

        MovingObjAnimationScript.animSpeed = 1 * gameSpeed;
        CountdownAnimationSpeedScript.animSpeed = 1 * gameSpeed;
        PlayerController.timeBeforeSpawnBullets = 3 / gameSpeed;
        PlayerController.spawnFrequency = 1 / gameSpeed;

    }

    // Update is called once per frame
    void Update () {
		
	}
}
