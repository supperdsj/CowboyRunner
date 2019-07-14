using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour {
    [SerializeField] GameObject pausePanel;
    [SerializeField] Button restartGameButton;
    [SerializeField] Text scoreText, pauseText;

    int score;

    void Start() {
        scoreText.text = score + "M";
        StartCoroutine(CountScore());
    }

    IEnumerator CountScore() {
        yield return new WaitForSeconds(.6f);
        score++;
        scoreText.text = score + "M";
        StartCoroutine(CountScore());
    }

    void OnEnable() {
        PlayerDied.endGame += PlayerDiedEndTheGame;
    }

    void OnDisable() {
        PlayerDied.endGame -= PlayerDiedEndTheGame;
    }

    void PlayerDiedEndTheGame() {
        if (!PlayerPrefs.HasKey("Score")) {
            PlayerPrefs.SetInt("Score", 0);
        }

        if (PlayerPrefs.GetInt("Score") < score) {
            PlayerPrefs.SetInt("Score", score);
        }

        pauseText.text = "Game Over";
        pausePanel.SetActive(true);
        restartGameButton.onClick.RemoveAllListeners();
        restartGameButton.onClick.AddListener(() => RestartGame());
        Time.timeScale = 0;
    }

    public void RestartGame() {
        Time.timeScale = 1;
        SceneManager.LoadScene("Gameplay");
    }

    public void GoToMainMenu() {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void PauseGame() {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        restartGameButton.onClick.RemoveAllListeners();
        restartGameButton.onClick.AddListener(() => ResumeGame());
    }

    public void ResumeGame() {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }
}
