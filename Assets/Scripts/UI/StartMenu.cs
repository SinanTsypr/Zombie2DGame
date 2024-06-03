using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartGame()
    {
        // Oyun sahnesini y�kler (�rne�in "GameScene")
        SceneManager.LoadScene("MainScene");
    }

    public void QuitGame()
    {
        // Oyundan ��kar
        Application.Quit();
    }
}
