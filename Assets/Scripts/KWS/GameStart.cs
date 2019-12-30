using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public GameObject FadeIn;

    public void GameStartButton()
    {
        StartCoroutine(FIn());
    }

    IEnumerator FIn()
    {
        FadeIn.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Ingame");

    }
}
