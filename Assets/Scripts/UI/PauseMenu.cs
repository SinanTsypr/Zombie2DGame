using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameManager gameManager;  // GameManager referansý

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape key pressed.");

            if (gameManager.pauseMenuCanvas.activeInHierarchy)
            {
                Debug.Log("Resuming game.");
                gameManager.ResumeGame();
            }
            else
            {
                Debug.Log("Pausing game.");
                gameManager.PauseGame();
            }
        }
    }

    //public void ResumeGame()
    //{
    //    pauseMenuCanvas.SetActive(false);
    //    Time.timeScale = 1f;  // Oyunu devam ettir
    //}

    //public void PauseGame()
    //{
    //    pauseMenuCanvas.SetActive(true);
    //    Time.timeScale = 0f;  // Oyunu durdur
    //}

    //public void RestartGame()
    //{
    //    Time.timeScale = 1f;  // Oyunu devam ettir
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // Mevcut sahneyi yeniden yükler
    //}

    //public void QuitGame()
    //{
    //    Time.timeScale = 1f;  // Oyunu devam ettir
    //    SceneManager.LoadScene("StartMenu");  // Baþlangýç menüsünü yükler
    //}
}
