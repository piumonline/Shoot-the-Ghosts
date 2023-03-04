using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameEnded = false;

    public GameObject gameOverUi;

    public GameObject WonUi;

    public int Numberofkills;

    private void Start()
    {
        gameEnded = false;
    }

    void Update()
    {
        if (gameEnded)

            return;

        if (Stats.lives <= 0)
        {
            EndGame();
        }

        if (GhostSpawn.EnemiesAlive == 0)
        {
            WonLevel();
            return;
        }

        else
        {
            return;
        }


    }

    private void EndGame()
    {
        Time.timeScale = 0f;
        gameOverUi.SetActive(true);
        gameEnded = true;
        //PausedMenu.GameIsPaused = true;
    }

    public void WonLevel()
    {
        Time.timeScale = 0f;
        GetComponent<AudioSource>().Play();
        WonUi.SetActive(true);
        gameEnded = true;
        //PausedMenu.GameIsPaused = true;
    }
}