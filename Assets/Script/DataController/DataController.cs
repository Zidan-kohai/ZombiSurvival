using System;
using UnityEngine;
using System.IO;

public class DataController : MonoBehaviour
{
    [SerializeField] private PanelManager panelManager;
    public Data data;

    [ContextMenu("Load")]
    public void SaveData()
    {
        data.countKill = Convert.ToInt32(panelManager.CountKill.text);
        data.countMoney = Convert.ToInt32(panelManager.CountMoney.text);
        File.WriteAllText(Application.streamingAssetsPath + "/JSON.json", JsonUtility.ToJson(data));
    }

    public void LoadData()
    {
        data = JsonUtility.FromJson<Data>(File.ReadAllText(Application.streamingAssetsPath + "/Json.json"));
        panelManager.CountKill.text = data.countKill.ToString();
        panelManager.CountMoney.text = data.countMoney.ToString();

    }

    private void Awake()
    {
        LoadData();
    }

    [System.Serializable]
    public class Data
    {
        public  int countKill; 

        public int countMoney;
    }
}
