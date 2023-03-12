using System;
using UnityEngine;
using System.IO;
using System.Diagnostics;


public class DataController : MonoBehaviour
{
    public static DataController Instanse;
    public Data data;


    private void Awake()
    {
        if(Instanse == null)
        {
            Instanse = this;
            DontDestroyOnLoad(gameObject);
        }else
        {
            Destroy(gameObject);
        }

        LoadData();
    }

    [ContextMenu("Save")]
    public void SaveData()
    {
        File.WriteAllText(Application.streamingAssetsPath + "/JSON.json", JsonUtility.ToJson(data));
    }
    [ContextMenu("Load")]
    public void LoadData()
    {
        data = JsonUtility.FromJson<Data>(File.ReadAllText(Application.streamingAssetsPath + "/Json.json"));

    }

    [System.Serializable]
    public class Data
    {
        public int countKill;
        public int countMoney;
    }
}