using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Won : MonoBehaviour
{
    public GameObject exitPanel;

    public GameObject WonUi;

    public int nextSceneLoad;

    private void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    public void onUserClickYesNo(int choice)//choice==0 no choice==1 yes
    {
        if (choice == 1)
        {
            SceneManager.LoadScene(0);
        }
        if (choice == 0)
        {
            exitPanel.SetActive(false);
            WonUi.SetActive(true);
        }
    }

    public void Continue()
    {

        //Move to next level
        SceneManager.LoadScene(nextSceneLoad);

        //Setting Int for Index
        if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
        {
            PlayerPrefs.SetInt("levelAt", nextSceneLoad);
        }


        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        Time.timeScale = 1f;

    }

    public void MainMenu()
    {
        WonUi.SetActive(false);
        exitPanel.SetActive(true);
    }
}
