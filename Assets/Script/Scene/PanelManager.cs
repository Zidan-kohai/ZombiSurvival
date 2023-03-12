using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{   
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject FallPanel;
    [SerializeField] private GameObject MainPanel;
    [SerializeField] private Player player;

    public Text Helth;
    public Text CountKill;
    public Text CountMoney;
    public Text Force;

    private void Start()
    {
        CountKill.text = DataController.Instanse.data.countKill.ToString();
        CountMoney.text = DataController.Instanse.data.countMoney.ToString();
    }
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

    public void SaveData()
    {
        DataController.Instanse.data.countMoney = Convert.ToInt32(CountMoney.text);
        DataController.Instanse.data.countKill = Convert.ToInt32(CountKill.text);
    }

    public void UpgradePlayerForce(int cost)
    {
        int currentMoney = Convert.ToInt32(CountMoney.text);
        if(currentMoney >= cost)
        {
            currentMoney -= cost;
            int CurrentForce = Convert.ToInt32(Force.text);
            Force.text = Convert.ToString(CurrentForce + 1);
            CountMoney.text = currentMoney.ToString();
        }
        OnUpgrateForce?.Invoke();
    }


    public Action OnUpgrateForce;
}
