using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeLeft;
    public Text timerText;

    void Update()
    {
        timeLeft -= Time.deltaTime;
        if(timeLeft <= 0) {
            timeLeft = 0;
            SceneManager.LoadScene("Game Over");
        } 
        timerText.text = timeLeft.ToString("F2");
    }
}
