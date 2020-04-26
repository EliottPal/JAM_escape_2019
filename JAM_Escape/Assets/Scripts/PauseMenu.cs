using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject gameOverUI;
    public GameObject player;
    bool isPaused = false;
    Vector3 originalPos;

    void Start() {
        originalPos = player.transform.position;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape) | Input.GetKeyDown(KeyCode.P)) {
            if (isPaused) {
                Resume();
            } else {
                Pause();
            }
        }
        if (Input.GetKeyDown(KeyCode.Keypad1)) {
            GameOver();
        }
    }

    public void GameOver() {
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Reset() {
        player.transform.position = originalPos;
        gameOverUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Pause() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
}