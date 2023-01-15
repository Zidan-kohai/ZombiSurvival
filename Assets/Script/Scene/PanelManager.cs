using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PanelManager : MonoBehaviour
{   
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject FallPanel;
    [SerializeField] private GameObject MainPanel;
    [SerializeField] private Player player;
    public void GamePause()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
        MainPanel.SetActive(false);
        player.GameStop = true;
        
    }

    public void GameReturn()
    {
        Time.timeScale = 1.0f;
        pausePanel.SetActive(false);
        MainPanel.SetActive(true);
        player.GameStop = false;
    }

    public void GameFail()
    {
        Time.timeScale = 0f;
        FallPanel.SetActive(true);
        MainPanel.SetActive(false);
        player.GameStop = true;

    }
}
