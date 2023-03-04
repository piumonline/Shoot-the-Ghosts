using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject exitPanel;

    public GameObject gameOverUi;

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Escape))
    //    {
    //        exitPanel.SetActive(true);
    //        PausedMenuUI.SetActive(false);
    //        gameOverUi.SetActive(false);
    //    }
    //}

    public void onUserClickYesNo(int choice)//choice==0 no choice==1 yes
    {
        if (choice == 1)
        {
            SceneManager.LoadScene(0);
        }
        if (choice == 0)
        {
            exitPanel.SetActive(false);
            gameOverUi.SetActive(true);
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        exitPanel.SetActive(true);
        gameOverUi.SetActive(false);
    }
}
