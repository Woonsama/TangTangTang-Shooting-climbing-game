using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public GameObject SettingPanel;
    public GameObject ScorePanel;

    public GameObject FadeOut;
    public void Setting()
    {
        SettingPanel.SetActive(true);
        Time.timeScale = 0;
    }
    
    public void CloseSetting()
    {
        SettingPanel.SetActive(false);
        Time.timeScale = 1; 
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Retry()
    {
        FadeOut.SetActive(true);
        StartCoroutine("RetryGame");
    }

    IEnumerable RetryGame()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("InGame");
    }

    public void ScoreBoard()
    {
        ScorePanel.SetActive(true);
    }
}
