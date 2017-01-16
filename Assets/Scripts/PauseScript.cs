﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    [SerializeField] GameObject PauseUI;
    private bool Paused = false;

    void Start()
    {
        PauseUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            Paused = !Paused;
        }

        if (Paused)
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }

        if (!Paused)
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1;
        }

    }

    public void Resume()
    {
        Paused = false;

    }

    public void Restart()
    {
        SceneManager.LoadScene("FirstLevel");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Paused = false;

    }

    public void Quit()
    {
        Application.Quit();
    }
}