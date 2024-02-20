using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainStageUI : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject gameOverPanel;
    private bool paused;
    [SerializeField] CharacterSelect charSelect;

    private void Start()
    {
        paused = false;
        pausePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        charSelect = GameObject.Find("CharacterSelect").GetComponent<CharacterSelect>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        paused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        paused = false;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(2);
    }

    public void CharacterSelect()       // Inter-scene transitions should probably be handled by some persistent scene manager?
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
        charSelect.enabled = true;
        charSelect.StartCoroutine("Initialize");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
