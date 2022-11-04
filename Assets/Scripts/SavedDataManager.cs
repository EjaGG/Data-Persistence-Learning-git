using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SavedDataManager : MonoBehaviour
{
    public static SavedDataManager Instance;

    public int highScore;
    public string newPlayerName;
    public string playerName;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
            LoadScore();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [System.Serializable]
    class SaveData
    {
        public int highScore;
        public string playerName;


    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.highScore = highScore;
        data.playerName = playerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/SavedData.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/SavedData.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highScore;
            playerName = data.playerName;
        }
    }
}
