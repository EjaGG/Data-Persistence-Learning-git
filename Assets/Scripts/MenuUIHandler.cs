using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public InputField inputPlayerName;
    public Text highScoreText;
    
    // Start is called before the first frame update\
    void Start()
    {
        inputPlayerName.text = SavedDataManager.Instance.playerName;
        highScoreText.text = "Best Score: " + SavedDataManager.Instance.playerName + ": " + SavedDataManager.Instance.highScore;
        //Debug.Log(SavedDataManager.Instance.highScore);

        //reset data
        //SavedDataManager.Instance.highScore = 5;
        //SavedDataManager.Instance.SaveScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        SavedDataManager.Instance.newPlayerName = inputPlayerName.text;
        //SavedDataManager.Instance.highScore = 0;
        Debug.Log(SavedDataManager.Instance.playerName);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

}
