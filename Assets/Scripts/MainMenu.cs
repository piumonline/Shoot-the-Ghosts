using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject exitPanel;

    public GameObject creditsUI;

    public GameObject optionsUi;

    //private bool creditsuiactive = false;

    private bool optionsUiactive = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (optionsUiactive == true)
            {
                SceneManager.LoadScene(0);
            }

            //if (creditsuiactive == true)
            //{
            //    optionsUi.SetActive(true);
            //}

            else
            {
                exitPanel.SetActive(true);
            }
        }
    }

    public void onUserClickYesNo(int choice)//choice==0 no choice==1 yes
    {
        if (choice == 1)
        {
            Application.Quit();
        }
        exitPanel.SetActive(false);
    }

    public void onUserClickStartButton()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    public void Options()
    {
        optionsUi.SetActive(true);
        optionsUiactive = true;
    }

    public void Credits()
    {
        optionsUi.SetActive(false);
        creditsUI.SetActive(true);
        //creditsuiactive = true;
    }
    public void Exit()
    {
        SceneManager.LoadScene(0);
    }

    public void Back()
    {
        creditsUI.SetActive(false);
        optionsUi.SetActive(true);
        optionsUiactive = true;
    }
}

