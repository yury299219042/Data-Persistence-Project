using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    public InputField inputName;

    public string nameHero;
    public int scoreBest;

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
        nameHero = inputName.text;
        Debug.Log("name " + nameHero);
    }
}