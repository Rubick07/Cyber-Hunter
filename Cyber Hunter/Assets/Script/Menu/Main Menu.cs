using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ChangeScene(string Stage)
    {
        SceneManager.LoadScene(Stage);
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


}
