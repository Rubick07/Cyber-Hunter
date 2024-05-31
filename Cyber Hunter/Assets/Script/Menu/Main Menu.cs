using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void ChangeScene(string Stage)
    {
        SceneManager.LoadScene(Stage);
        Time.timeScale = 1f;
    }

    public void NextScene()
    {
        Debug.Log(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Keluar");
        Application.Quit();
    }

    public void LevelUnlock()
    {
        if(SceneManager.GetActiveScene().name == "Prologue")
        {
            Debug.Log("Unlock tutorial");
            if(PlayerPrefs.GetInt("LevelAt") < 2) PlayerPrefs.SetInt("LevelAt", 2);
        }
        else if(SceneManager.GetActiveScene().name == "DialogAfterTutor")
        {

            if (PlayerPrefs.GetInt("LevelAt") < 3) PlayerPrefs.SetInt("LevelAt", 3);

        }
        else if (SceneManager.GetActiveScene().name == "DialogAfterS1")
        {
            if (PlayerPrefs.GetInt("LevelAt") < 4) PlayerPrefs.SetInt("LevelAt", 4);

        }
        else if (SceneManager.GetActiveScene().name == "DialogAfterS2")
        {
            if (PlayerPrefs.GetInt("LevelAt") < 5) PlayerPrefs.SetInt("LevelAt", 5);

        }
        else if (SceneManager.GetActiveScene().name == "DialogAfterS3")
        {
            if (PlayerPrefs.GetInt("LevelAt") < 6) PlayerPrefs.SetInt("LevelAt", 6);
        }
    }



}
