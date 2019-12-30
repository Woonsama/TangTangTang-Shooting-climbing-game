using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int highScore;
    public int score;

    private float playTime;

    public Text timeText;
    public Text hitText;

    public static int hit;

    void Start()
    {
        hit = 0;
        playTime = 0;
    }

    void Update()
    {
        timeText.text = "Time : " + (int)playTime + "s";
        hitText.text = "Hit : " + hit;

        if(!PlayerCtrl.isDie)
        {
            playTime += Time.deltaTime;
        }
        else
        {
            //
        }
    }
}
