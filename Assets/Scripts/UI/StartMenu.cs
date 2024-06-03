using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartGame()
    {
        // Oyun sahnesini yükler (örneðin "GameScene")
        SceneManager.LoadScene("MainScene");
    }

    public void QuitGame()
    {
        // Oyundan çýkar
        Application.Quit();
    }
}
