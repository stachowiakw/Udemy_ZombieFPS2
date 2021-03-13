using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private Button buttonPlayAgain;
    [SerializeField] private Button buttonQuit;
    [SerializeField] private Button buttonPlayAgain2;
    [SerializeField] private Button buttonQuit2;

    void Start()
    {
        buttonPlayAgain.onClick.AddListener(PlayAgain);
        buttonQuit.onClick.AddListener(QuitGame);
        buttonPlayAgain2.onClick.AddListener(PlayAgain);
        buttonQuit2.onClick.AddListener(QuitGame);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
