using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTime : MonoBehaviour
{
    public Text scoreText;

    void Start()
    {
        finalScore();
    }

    public void finalScore()
    {
        scoreText.text = "TIME: " + PlayerPrefs.GetString("time");
    }
}
