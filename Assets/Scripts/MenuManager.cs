using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    public InputField inputName;

    public string nameHero;
    public string namePlayer;
    public int bestScore;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        LoadRecord();
        if (nameHero != "")
        {
            GameObject.Find("Placeholder").GetComponent<Text>().text = nameHero;
        }
        GameObject.Find("Best Score Text").GetComponent<Text>().text = "Best Score: " + nameHero + " : " + bestScore;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
   
    public void QuitGame()
    {
        Application.Quit();
    }

    public void SetPlayerName()
    {
        namePlayer = inputName.text;
        
    }

    [System.Serializable]
    class SaveData
    {
        public string nameBest;
        public int scoreBest;
    }

    public void SaveNewRecord(string name, int score)
    {
        SaveData data = new SaveData();
        data.nameBest = name;
        data.scoreBest = score;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadRecord()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            nameHero = data.nameBest;
            bestScore = data.scoreBest;
        }
    }
}
