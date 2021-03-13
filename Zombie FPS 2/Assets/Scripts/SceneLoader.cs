using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private Button buttonPlayAgain;
    [SerializeField] private Button buttonQuit;

    void Start()
    {
        buttonPlayAgain.onClick.AddListener(PlayAgain);
        buttonQuit.onClick.AddListener(QuitGame);
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
