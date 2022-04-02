using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public Text timerText;
    public int hours = 14;
    public int minutes = 00;
    public float timeForFiveMins = 10.0f;
    private float currentTIme = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        UpdateTimer();
    }

    // Update is called once per frame
    void Update()
    {
        currentTIme += Time.deltaTime;
        if (currentTIme >= timeForFiveMins)
        {
            SetNewTime();
        }
    }

    public void SetNewTime()
    {
        minutes -= 5;
        if (minutes < 0)
        {
            hours -= 1;
            minutes = 55;
        }
        currentTIme = 0.0f;
        UpdateTimer();

    }

    private void UpdateTimer()
    {
        timerText.text = hours + ":";
        if (minutes < 10)
        {
            timerText.text += "0"+minutes;
        }
        else timerText.text += minutes;
    }
}
