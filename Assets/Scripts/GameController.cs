using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour {

    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public GUIText scoreText;
    public GUIText restartText;
    public GUIText gameoverText;
    private int score;

    public bool restart;
    public bool gameover;

    void Start()
    {
        restart = false;
        gameover = false;

        restartText.text = "";
        gameoverText.text = "";

        score = 0;
        UpdateScore();
        StartCoroutine(spawnWaves());
    }

    void Update()
    {
        if(restart)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
                
            }
        }
    }

    IEnumerator spawnWaves()
    {
        yield return new WaitForSeconds(startWait);

        while(true)
       {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameover == true)
            {
                restartText.text = "Press 'R' to restart";
                restart = true;
                break;
            }
        }
    }

    public void AddScore(int scoreAdded)
    {
        score += scoreAdded;
        UpdateScore();
    }
    

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameoverText.text = "Game Over. Thanks for playing!!!";
        gameover = true;
    }
}
