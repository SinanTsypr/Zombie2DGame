using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public GameObject pauseMenuCanvas;
    public TMP_Text scoreText;  // TextMeshPro kullanýmý
    private int score;

    private void Start()
    {
        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(false);  // Baþlangýçta oyun bitti ekranýný gizler
        }

        if (pauseMenuCanvas != null)
        {
            pauseMenuCanvas.SetActive(false);  // Baþlangýçta pause menüsünü gizler
        }

        // Puaný sýfýrla
        score = 0;
        UpdateScoreText();
    }

    public void GameOver()
    {
        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(true);  // Oyun bitti ekranýný gösterir
            Debug.Log("GameOverCanvas is now active.");
        }
        else
        {
            Debug.LogError("GameOverCanvas is not assigned in GameManager script.");
        }
        Time.timeScale = 0f;  // Oyunu durdur
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;  // Oyunu devam ettir
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // Mevcut sahneyi yeniden yükler
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;  // Oyunu devam ettir
        SceneManager.LoadScene("GameStartUI");  // Baþlangýç menüsünü yükler
    }

    public void ResumeGame()
    {
        if (pauseMenuCanvas != null)
        {
            pauseMenuCanvas.SetActive(false);
            Debug.Log("Resuming game.");
        }
        Time.timeScale = 1f;  // Oyunu devam ettir
    }

    public void PauseGame()
    {
        if (pauseMenuCanvas != null)
        {
            pauseMenuCanvas.SetActive(true);
            Debug.Log("Pausing game and showing pause menu.");
        }
        else
        {
            Debug.LogError("PauseMenuCanvas is not assigned in GameManager script.");
        }
        Time.timeScale = 0f;  // Oyunu durdur
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
        else
        {
            Debug.LogError("ScoreText is not assigned in GameManager script.");
        }
    }
}
