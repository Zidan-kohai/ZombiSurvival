using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PanelManager : MonoBehaviour
{   
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject FallPanel;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private Player player;
    public void GamePause()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
        pauseButton.SetActive(false);
        player.GameStop = true;
        
    }

    public void GameReturn()
    {
        Time.timeScale = 1.0f;
        pausePanel.SetActive(false);
        pauseButton?.SetActive(true);
        player.GameStop = false;
    }
}
