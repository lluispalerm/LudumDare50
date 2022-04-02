using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public int hours = 14;
    public int minutes = 00;
    public float timeForFiveMins = 10.0f;
    public bool isTransitioning = false;
    private float currentTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isTransitioning)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= timeForFiveMins)
            {
                ApplyTimeLoss(0, 5);
            }
        }
    }

    public void ApplyTimeLoss(int h, int m)
    {
        hours -= h;
        minutes -= m;
        if (minutes < 0)
        {
            hours -= 1;
            minutes = 55;
        }
        currentTime = 0.0f;
        UpdateText();
    }

    public void Reset()
    {
        hours = 14;
        minutes = 0;
        isTransitioning = true;
        currentTime = 0.0f;
        UpdateText();
    }

    private void UpdateText()
    {
        if (minutes < 10)
        {
            timerText.text = hours + ":" + "0" + minutes;
        }
        else timerText.text = hours + ":" + minutes;
    }
}
